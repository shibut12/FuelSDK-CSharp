using FuelSDK.MobilePush;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.Test
{
    [TestFixture()]
    class ContactListTest
    {
        ETClient client;
        
        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
            

        }

        [Test()]
        public RefreshListResponse RefreshList()
        {
            var listid = "7d5a9bd7-0cad-e711-80d3-1402ec6b9528"; //Get the list id from marketing cloud UI and replace it here.
            var clist = new ContactList
            {
                AuthStub = client
            };
            var response = clist.RefreshList(listid);
            Assert.IsNotNull(response.TokenId);
            Assert.IsNotNull(response.LastPublishDate);
            return response;
        }

        [Test()]
        public void GetRefreshListStatus()
        {
            var listReponse = RefreshList();
            var listid = "7d5a9bd7-0cad-e711-80d3-1402ec6b9528"; //Get the list id from marketing cloud UI and replace it here.
            var clist = new ContactList
            {
                AuthStub = client
            };
            var response = clist.GetRefreshListStatus(listid, listReponse.TokenId);
            Assert.IsNotNull(response.TokenId);
            Assert.IsNotNull(response.LastPublishDate);
        }


    }
}
