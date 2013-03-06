using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Suzy.BO;

namespace Suzy.Bo.Test
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
        public void TestAccountEquals()
        {
            Account newAccount = new Account();
            newAccount.name = "Алекс";
            Account newAccount1 = new Account();
            newAccount1.name = "Алекс";
            Assert.Equals(newAccount == newAccount1, newAccount.Equals(newAccount1));

        }

        [TestMethod]
        public void TestLocaionAreaEquals()
        {
            LocationArea newlocation = new LocationArea();
            newlocation.name = "Киев";
            LocationArea newlocationCopy = new LocationArea();
            newlocationCopy.name = "Киев";
            Assert.Equals(newlocation == newlocationCopy, newlocation.Equals(newlocationCopy));
        }
    }
}
