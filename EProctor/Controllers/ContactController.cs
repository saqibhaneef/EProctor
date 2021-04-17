using EProctor.Models.UserModels;
using EProctor.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Controllers
{

    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public IActionResult Index()
        {
            var model = _contactRepository.GetAllContacts();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Contact contact = _contactRepository.GetContact(id);
            if(contact==null)
            {
                Response.StatusCode = 404;
                return View("CourseNotFound", id);
            }
            else
            {
                ContactDetailsViewModel contactDetailsViewModel = new ContactDetailsViewModel()
                {
                    Contact = _contactRepository.GetContact(id),
                    PageTitle = "Details",
                };
                return View(contactDetailsViewModel);
            }
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                Contact newContact = _contactRepository.Add(contact);
                return View();

            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Contact contact = _contactRepository.GetContact(id);
            ContactDeleteViewModel contactDeleteViewModel= new ContactDeleteViewModel
            {
                Id = contact.Id,
                Name=contact.Name,
                Email=contact.Email,
                Subject=contact.Subject,
                Message=contact.Message,
            };
            return View(contactDeleteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(ContactDeleteViewModel model)
        {
            _contactRepository.Delete(model.Id);

            return RedirectToAction("Index");
        }
    }
}
