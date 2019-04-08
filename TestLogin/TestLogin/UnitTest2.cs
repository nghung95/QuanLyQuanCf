using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyQuanCF.DAO;
using QuanLyQuanCF;
using System.Data;
using System.Globalization;

namespace TestLogin
{
    [TestClass]
    public class UnitTest2
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get { return testContext; }
            set { testContext = value; }
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
