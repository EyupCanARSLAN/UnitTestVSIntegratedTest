using AppLayer.Interface;
using System.Collections.Generic;
using DbLayer;
using System.Linq;
namespace AppLayer.Tasks
{
    public class PersonMessageTask : IPersonMessage
    {
        private readonly IntegrationTestSampleEntities _dbEntities;
        public PersonMessageTask(IntegrationTestSampleEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }
        public MessageFromPerson GetMessageById(int messageId)
        {
            return _dbEntities.MessageFromPerson.FirstOrDefault(x => x.Id == messageId);
        }
        public List<MessageFromPerson> GetMessageListFromPerson(int personId)
        {
            return _dbEntities.MessageFromPerson.Where(x => x.PersonId == personId).ToList();
        }
        public int SetMessageFromPerson(int personId, string personMessage)
        {
            var message = new MessageFromPerson();
            message.PersonId = personId;
            message.Message = personMessage;
            _dbEntities.MessageFromPerson.Add(message);
            _dbEntities.SaveChanges();
            return message.Id;
        }
    }
}
