using System;
using AFEI.Business;
using AFEI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AFEI.Test
{
    [TestClass]
    public class ClientTest
    {
        ClientBusiness clientBusiness = new ClientBusiness();

        [TestMethod]
        public void CreateClient()
        {
            Client  client = new Client();
            client.FirstName = "Juana";
            client.LastName = "Perez";
            client.Phone = "1233444";
            clientBusiness.Create(client);
        }
    }
}
