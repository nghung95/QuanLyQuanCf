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

            int idFood = Int32.Parse(TestContext.DataRow[0].ToString());
            string name = TestContext.DataRow[1].ToString();
            int id = Int32.Parse(TestContext.DataRow[2].ToString());
            float price = float.Parse(TestContext.DataRow[3].ToString());
            bool expected = Boolean.Parse(TestContext.DataRow[4].ToString());

            FoodDAO login = new FoodDAO();

            bool actual = login.UpdateFood(idFood,name, id, price);

            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestTimKiem.csv", "TestTimKiem#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestTimKiem.csv"), TestMethod]
        public void TestTimKiem()
        {
            string name = TestContext.DataRow[0].ToString();
            bool expected = Boolean.Parse(TestContext.DataRow[1].ToString());

            fAdmin search = new fAdmin();

            bool actual = false;
            if (search.SearchFoodByName(name).Count() > 0)
                actual = true;


            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestTimKiemByCategoryId.csv", "TestTimKiemByCategoryId#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestTimKiemByCategoryId.csv"), TestMethod]
        public void TestTimKiemByCategoryId()
        {
            int id = Int32.Parse(TestContext.DataRow[0].ToString());
            bool expected = Boolean.Parse(TestContext.DataRow[1].ToString());

            FoodDAO search = new FoodDAO();

            bool actual = false;
            if (search.GetFoodByCategoryID(id).Count() > 0)
                actual = true;


            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestGetUncheckBillIDByTableID.csv", "TestGetUncheckBillIDByTableID#csv", DataAccessMethod.Sequential), DeploymentItem("TestLogin\\TestGetUncheckBillIDByTableID.csv"), TestMethod]
        public void TestGetUncheckBillIDByTableID()
        {
            int billId = Int32.Parse(TestContext.DataRow[0].ToString());
            bool expected = Boolean.Parse(TestContext.DataRow[1].ToString());

            BillDAO bill = new BillDAO();

            bool actual = false;
            if (bill.GetUncheckBillIDByTableID(billId) != -1)
                actual = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
