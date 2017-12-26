using System;
using AppLayer.Tasks;
using DbLayer;
namespace AppLayer
{
    public class Controller : IDisposable
    {
        private readonly IntegrationTestSampleEntities dbCon;
        private readonly PersonTask personTask;
        private readonly PersonMessageTask messageTask;
        public Controller()
        {
            dbCon = new IntegrationTestSampleEntities();
            personTask = new PersonTask(dbCon);
            messageTask = new PersonMessageTask(dbCon);
        }
        public int CreatePerson(string name, string surname)
        {
            return personTask.CreatePerson(name, surname);
        }
        public int SetMessage(int personId, string personMessage)
        {
            return messageTask.SetMessageFromPerson(personId, personMessage);
        }
        public void Dispose()
        {
            dbCon.Dispose();
        }
    }
}
