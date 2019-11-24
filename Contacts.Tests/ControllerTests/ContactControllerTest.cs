using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using Contacts.Common.Core.Utility.Interface;
using Contacts.Common.Proxy.RestProxy.Contract.ContactsDataService;
using Contacts.Controllers;
using Contacts.Data.Domain.Model;
using Contacts.Models.Contact;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Contacts.Tests
{
    [TestClass]
    public class ContactControllerTest
    {
        #region Declarations
        private Mock<IContactLogger> _contactLoggerMock;
        private Mock<IContactDataServiceProxy> _contactDataServiceProxyMock;

        private ContactController _controllerToTest;
        #endregion Declarations

        #region Test Initializations
        [TestInitialize]
        public void Initialize()
        {
            this._contactLoggerMock = new Mock<IContactLogger>();
            this._contactDataServiceProxyMock = new Mock<IContactDataServiceProxy>();

            this._controllerToTest =
                new ContactController(
                    _contactLoggerMock.Object,
                    _contactDataServiceProxyMock.Object);
        }
        #endregion Test Initializations

        #region Test Methods
        [TestMethod]
        public async Task Index_Test()
        {
            //--- Arrange
            _contactDataServiceProxyMock
                .Setup(a => a.GetAllContactsDetails()).ReturnsAsync(GetContactListDummy());

            //--- Act
            var result = await _controllerToTest.Index() as ViewResult;

            //---Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(List<ContactViewModel>));


        }
        #endregion Test Methods

        #region Private Methods
        private static IList<Contact> GetContactListDummy()
        {
            var dummyData = new List<Contact>() { 
                new Contact()
                {
                    ID=101,
                    FirstName="Test",
                    LastName="Test",
                    Email="xyz@gmail.com",
                    PhoneNumber="+0000000000",
                    Status="Active"
                }
            };
            return dummyData;
        }
        #endregion
    }
}
