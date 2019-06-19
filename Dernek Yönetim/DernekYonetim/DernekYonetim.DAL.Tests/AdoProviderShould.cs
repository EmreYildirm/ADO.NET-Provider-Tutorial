using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DernekYonetim.DAL.Tests
{
    [TestClass]
    public class AdoProviderShould
    {
        [TestMethod]
        public void GetThreeHareketTipiWithScalar()
        {
            var cmdText = "SELECT COUNT(*) FROM HareketTip WHERE Id >= @Id";
            AdoProvider provider = new AdoProvider("Server= PC-517; Database= DernekYonetimDb; Integrated Security = true;");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", 2);
            var result=provider.ExecuteScalar<int>(cmdText,parameters);
            Assert.AreEqual(2,result);
        }

    }
}
