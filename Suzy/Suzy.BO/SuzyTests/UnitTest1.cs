using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suzy.BO;

namespace SuzyTests
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAccountListAddGet()
        {
            Account newAccount = new Account();
            newAccount.name = "Алекс";
            AccountList.Add(newAccount);
            Assert.Equals(newAccount, AccountList.Get());
        }

        [TestMethod]
        public void TestMethod2()
        {
            LocationArea newlocation = new LocationArea();
            newlocation.name = "Киев";
            LocationList.Add(newlocation);
            Assert.Equals(newlocation, LocationList.Get());
        }

        [TestMethod]
        public void TestAccountAreaEquals()
        {
            Account newAccount = new Account();
            newAccount.name = "Алекс";
            Account newAccount1 = new Account();
            newAccount.name = "Алекс";
            Assert.Equals(newAccount == newAccount1, newAccount.Equals(newAccount1));

        }
        public void TestAccountAreaEquals()
        {
            LocationArea newlocation = new LocationArea();
            newlocation.name = "Киев";
            LocationArea newlocation1 = new LocationArea();
            newlocation.name = "Киев";
            Assert.Equals(newlocation == newlocation1, newlocation.Equals(newlocation1));
        }
    }
}
