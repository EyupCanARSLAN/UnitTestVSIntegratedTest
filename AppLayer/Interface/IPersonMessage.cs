using DbLayer;
using System.Collections.Generic;
namespace AppLayer.Interface
{
    /// <summary>
    /// Message Task defination
    /// </summary>
    public interface IPersonMessage
    {
        /// <summary>
        ///  Create message record that is created by person, on Db. Return integer value that is the record pk on database
        /// </summary>
        /// <param name="personId">person Id</param>
        /// <param name="personMessage">person message</param>
        /// <returns>integer</returns>
        int SetMessageFromPerson(int personId, string personMessage);
        /// <summary>
        /// Get created message by messageId 
        /// </summary>
        /// <param name="messageId">int messageId</param>
        /// <returns>MessageFromPerson</returns>
        MessageFromPerson GetMessageById(int messageId);
        /// <summary>
        /// Get person messages from personId
        /// </summary>
        /// <param name="personId">int personId</param>
        /// <returns>List<MessageFromPerson></returns>
        List<MessageFromPerson> GetMessageListFromPerson(int personId);
    }
}
