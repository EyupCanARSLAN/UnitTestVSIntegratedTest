using DbLayer;
namespace AppLayer.Interface
{
    /// <summary>
    /// Person task definations
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        ///  Create person record on Db. Return integer value that is the record pk on database
        /// </summary>
        /// <param name="name">person name</param>
        /// <param name="surname">person surname</param>
        /// <returns>integer</returns>
        int CreatePerson(string name, string surname);
        /// <summary>
        /// Return person record for given personId
        /// </summary>
        /// <param name="personId">person Id</param>
        /// <returns>Person object</returns>
        Person GetPersonById(int personId);
    }
}