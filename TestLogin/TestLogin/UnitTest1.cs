using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyQuanCF.DAO;
using QuanLyQuanCF;
using System.Data;

namespace TestLogin
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestData.csv"), TestMethod]
        public void TestLogin()
        {
            string username = TestContext.DataRow[0].ToString();
            string password = TestContext.DataRow[1].ToString();
            bool expected = Boolean.Parse(TestContext.DataRow[2].ToString());

            fLogin login = new fLogin();

            bool actual = login.Login(username, password);

            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestThemThucAn.csv", "TestThemThucAn#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestThemThucAn.csv"), TestMethod]
        public void TestThemThucAn()
        {
            int id = Int32.Parse(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();
            float price = float.Parse(TestContext.DataRow[2].ToString());
            bool expected = Boolean.Parse(TestContext.DataRow[3].ToString());

            FoodDAO login = new FoodDAO();

            bool actual = login.InsertFood(name,id,price);

            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestXoaThucAn.csv", "TestXoaThucAn#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestXoaThucAn.csv"), TestMethod]
        public void TestXoaThucAn()
        {
            
            int id = Int32.Parse(TestContext.DataRow[0].ToString());
            
            bool expected = Boolean.Parse(TestContext.DataRow[1].ToString());

            FoodDAO login = new FoodDAO();

            bool actual = login.DeleteFood(id);

            Assert.AreEqual(expected, actual);
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestUpdateFood.csv", "TestUpdateFood#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestUpdateFood.csv"), TestMethod]
        public void TestUpdateFood()
        {
            //string a = TestContext.DataRow[0].ToString();
            int idFood = Int32.Parse(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();
            int id = Int32.Parse(TestContext.DataRow[2].ToString());
            float price = float.Parse(TestContext.DataRow[3].ToString());
            bool expected = Boolean.Parse(TestContext.DataRow[4].ToString());

            FoodDAO login = new FoodDAO();

            bool actual = login.UpdateFood(idFood,name, id, price);

            Assert.AreEqual(expected, actual);
        }
    }
}
