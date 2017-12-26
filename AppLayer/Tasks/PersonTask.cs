using AppLayer.Interface;
using System.Linq;
using DbLayer;
namespace AppLayer.Tasks
{
    public class PersonTask : IPerson
    {
        private readonly IntegrationTestSampleEntities _dbEntities;
        public PersonTask(IntegrationTestSampleEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }
        public int CreatePerson(string name, string surname)
        {
            var person = new Person();
            person.Name = name;
            person.Surname = surname;
            _dbEntities.Person.Add(person);
            _dbEntities.SaveChanges();
            return person.Id;
        }
        public Person GetPersonById(int personId)
        {
           return _dbEntities.Person.FirstOrDefault(x => x.Id == personId);
        }
    }
    public class TestPerson
    {
        public Person FindPersonById(int personId)
        {
            using (var dbCon = new IntegrationTestSampleEntities())
            {
                return dbCon.Person.FirstOrDefault(x => x.Id == personId);
            }
        }
    }
}