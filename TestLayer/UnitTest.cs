using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DbLayer;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace TestLayer
{
    /// <summary>
    /// Aşağıdaki kod parçacıklarında Unit Test örnekleri verilmeye çalışılmıştır.
    /// Burada kullanılan Ef-DbCon objeleri gerçek objeler olmayıp, gerektiği yerlerde sahteleri oluşturulup kullanılmıştır.
    /// EfDbCon objeleri test edileceği zaman,Ef de tanımlı database yapısı bellek üzerinden geçici olarak oluşturulur.
    /// Bu olaya MemoryTest-Bellek testi de denir. Buradaki olayın Integration testle karıştırılmaması önemlidir.
    /// 
    /// At the given piece of code, I try to give examples about on Unit Test.
    /// The functions that we want to Unit Test on this, I used EfDbCon objects. This object was mocked.
    /// During the test time EfDCon objects is created on Memory as permamently.This can be called as Memoty Test.
    /// </summary>
   
    [TestClass]
    //[TestInitialize]
    //[TestMethod]
    //[TestCleanup]
    public class UnitTest
    {
        Mock<DbSet<Person>> moqSetForPersonDbSet;
        Mock<IntegrationTestSampleEntities> mockDbConContext;
        [TestInitialize]
        public void InitalizeMoq()
        {
            //Eng Explanation
            //Ef deki objeleri test etmek için, DbCon clası moqlanıyor. Böylece buradaki Database de Memory test de yapılabilecek.
            //Moq the DbCon class. Also this give us ability to test Ef class and object as MemoryTest.
            mockDbConContext = new Mock<IntegrationTestSampleEntities>();
            //Tr Explanation
            //Ef deki objeleri test etmek için, DbSet objesi moq lanıyor. Böylece burada Database de MemoryTest yapılabilecek.
            //Moq the DbSet class. Also this give us ability to test Ef class and object as MemoryTest.
            moqSetForPersonDbSet = new Mock<DbSet<Person>>();
        }
        [TestMethod]
        public void CreatePersonTest()
        {
            //Eng Explanation
            //We want to make Unit Test on PersonTask.CreatePerson.  Input("can", "arslan"), Output(0) are expected result for this test.
            //But This class's constructor is need EfDbCon object as input. In Unit Test, externel functions are ignored. For this reason 
            // EfObjects is mocked by MOQ framework

            //Tr Explanation
            //personTask.CreatePerson fonk üzerinde UnitTest yapmak istiyoruz. Input("can", "arslan"), Output(0) olarak bekliyoruz. 
            //Bu sırada fonk.un bulunduğu classdaki Constructor input parametresi olarak EfDbCon objesi istiyor.
            //Unit Test sırasında biz sadece fonk. ve yerel yapılarına odaklanıcaz. Ef objeleri burada harici fonk olduğu için bu objelerin
            //gerekli olduğu yerlerde sahte objeler kullanacağız.
            mockDbConContext.Setup(m => m.Person).Returns(moqSetForPersonDbSet.Object);
            var personTask = new AppLayer.Tasks.PersonTask(mockDbConContext.Object);

 
            var result = personTask.CreatePerson("can", "arslan");
            Assert.AreEqual(result, 0);
        }
        [TestMethod]
        public void GetPersonById()
        {
            //Bu örnekteki Unit Test yapılan fonk. ise Input("1"), Output("Deneme") olarak vermesi beklenir.
            //Bu sırada fonk.un bulunduğu classdaki Constructor input parametresi olarak EfDbCon objesi istiyor.
            //Burada fonk iç yapısına baktığımızda, Ef DbSet objelerinin kullanıldığınıda görüyoruz.
            //Ben burada DbContext i moqlarken, DbCon uda moqlamayı ve içini aşağıdaki gibi bir dumy değer ile 
            //doldurmayı tercih ettim. Aslın da bu Constructor  input parametresi olarak EfDbCon objesi almasa idi
            //hiç bir şekilde EfDbCon u moq lama ile uğraşmıyacaktık :) Esasında buraki örnekler SOLID açısından da oldukça kötü olabilir ;) 

            //At this Unit Test, function that we want to test,  Input("1"), Output("Deneme") as expected result.
            //But This class's constructor is need EfDbCon object as input. When I mocked DbContext, I prefer to mock DbCon  and fill this a dumy value.
            //At there,  if Constructor did not need  EfDbCon object as input, we don't have to mock Ef objects. :) If to be honest, this implementation is very ugly and unacceptable 
            //according to SOLID prencibles. ;) 

            var data = new Person
            {
                Id = 1,
                Name = "Deneme",
                Surname = "Testi"
            };
            var personList = new List<Person>
            {
              data
            }.AsQueryable();
            moqSetForPersonDbSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personList.Provider);
            moqSetForPersonDbSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personList.Expression);
            moqSetForPersonDbSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personList.ElementType);
            moqSetForPersonDbSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(() => personList.GetEnumerator());
            mockDbConContext.Setup(c => c.Person).Returns(moqSetForPersonDbSet.Object);
            var personTask = new AppLayer.Tasks.PersonTask(mockDbConContext.Object);
            var result = personTask.GetPersonById(1);
            Assert.AreEqual(result.Name, "Deneme");
        }
    }
}