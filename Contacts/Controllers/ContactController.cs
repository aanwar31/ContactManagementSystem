using Contacts.Common.Core.Utility.Interface;
using Contacts.Common.Proxy.RestProxy.Contract.ContactsDataService;
using Contacts.Data.Domain.Model;
using Contacts.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Controllers
{
    public class ContactController : BaseController
    {
        #region Declarations
        private readonly IContactLogger _contactLogger;
        private readonly IContactDataServiceProxy _contactDataServiceProxy;
        #endregion Declarations

        #region Constructors
        public ContactController(IContactLogger contactLogger,
            IContactDataServiceProxy contactDataServiceProxy)
        {
            this._contactLogger = contactLogger;
            this._contactDataServiceProxy = contactDataServiceProxy;
        }
        #endregion Constructors

        #region ActionResult Methods
        // GET: Contact
        public async Task<ActionResult> Index()
        {
            _contactLogger.Info("Start");

            var entityDataModel = await _contactDataServiceProxy.GetAllContactsDetails();
            List<ContactViewModel> viewModel = null;

            if (entityDataModel.Count>0)
            {
                 viewModel = MapEntityToViewModel(entityDataModel);
            }
            
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ContactViewModel model)
        {
            try
            {
                Contact entityModel = MapViewModelToEntity(model);

                var result = await _contactDataServiceProxy.CreateContactDetails(entityModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Demo/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(decimal id)
        {
            var result =await _contactDataServiceProxy.GetDetails(id);

            ContactViewModel model = new ContactViewModel
            {
                ID=result.ID,
                FirstName=result.FirstName,
                LastName=result.LastName,
                Email=result.Email,
                PhoneNumber=result.PhoneNumber,
                Status=result.Status
            };

            return View(model);
        }

        #endregion ActionResult Methods



        #region Private Methods
        private static List<ContactViewModel> MapEntityToViewModel(IList<Data.Domain.Model.Contact> entityDataModel)
        {
            List<ContactViewModel> viewModel = new List<ContactViewModel>();

            foreach (var data in entityDataModel)
            {
                var model = new ContactViewModel
                {
                    ID = data.ID,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Email = data.Email,
                    PhoneNumber = data.PhoneNumber,
                    Status = data.Status
                };

                viewModel.Add(model);
            }

            return viewModel;
        }

        private Contact MapViewModelToEntity(ContactViewModel model)
        {
            Contact data = new Contact 
            {
                FirstName=model.FirstName,
                LastName=model.LastName,
                Email=model.Email,
                PhoneNumber=model.PhoneNumber,
                Status="Active"
            };
            return data;
        }

        #endregion Private Methods

    }
}