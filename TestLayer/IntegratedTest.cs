using DbLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestLayer
{
    /// <summary>
    /// Eng Explanation: 
    /// 
    /// At the given piece of code, I try to give examples about on IntegratedTest.
    /// In this functions that we want to test a functions all components(object, instance vs.) on this.
    /// For this reason in Ef-DbCon, I used real database connection. You can find dbConnection string on AppConfig.
    /// 
    /// 
    /// Tr Explanation:
    /// 
    /// Aşağıdaki kod parçacıklarında IntegratedTest örnekleri verilmeye çalışılmıştır.
    /// Burada kullanılan Ef-DbCon objeleri,sahte objeler değildir!!! Database ile bağlantılı olan bu objeler için
    /// AppConfig de Database bağlantısı bulunmaktadır.
    /// </summary>
    [TestClass]
    public class IntegratedTest
    {
        IntegrationTestSampleEntities dbCon;
        [TestInitialize]
        public void InitalizeMoq()
        {
            dbCon= new IntegrationTestSampleEntities();
        }
        [TestMethod]
        public void CreatePersonTest()
        {
            var personTask = new AppLayer.Tasks.PersonTask(dbCon);
            int result = personTask.CreatePerson("can", "arslan");
            Assert.AreNotEqual(result,0);
        }
        [TestMethod]
        public void GetPersonById()
        {
            var person = new AppLayer.Tasks.PersonTask(dbCon);
            var personIdAsResult = person.CreatePerson("Deneme", "Testi");
            var result = person.GetPersonById(personIdAsResult);
            Assert.AreEqual(result.Name,"Deneme");
        }
        [TestCleanup]
        public void ClearConnection()
        {
            dbCon.Dispose();
            dbCon = null;
        }
    }
}
