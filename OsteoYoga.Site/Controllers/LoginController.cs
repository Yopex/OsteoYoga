﻿using System.Collections.Generic;
using System.Web.Mvc;
using OsteoYoga.Domain.Models;
using OsteoYoga.Helper;
using OsteoYoga.Helper.Helpers;
using OsteoYoga.Repository.DAO;
using OsteoYoga.Repository.DAO.Implements;
using OsteoYoga.Repository.DAO.Interfaces;
using OsteoYoga.Resource.Contact;
using OsteoYoga.Site.ViewResults;

namespace OsteoYoga.Site.Controllers
{
    public class LoginController : BaseController.BaseController
    {
        public ContactRepository ContactRepository { get; set; }
        public OfficeRepository OfficeRepository { get; set; }
        public DurationRepository DurationRepository { get; set; }
        public ProfileRepository ProfileRepository { get; set; }

        public LoginController()
        {
            ContactRepository = new ContactRepository();
            OfficeRepository = new OfficeRepository();
            DurationRepository = new DurationRepository();
            ProfileRepository = new ProfileRepository();
        }
        
        public PartialViewResult Index()
        {
            if (SessionHelper.GetInstance().CurrentUser != null)
            {
                return GoTorendezVousPage();
            }
            return PartialView("Index");    
        }

        private PartialViewResult GoTorendezVousPage()
        {
            DateViewResult dateViewResult = new DateViewResult()
            {
                Offices = OfficeRepository.GetAll(),
                Durations = DurationRepository.GetAll()
            };
            return PartialView("~/Views/RendezVous/Index.cshtml", dateViewResult);
        }

        [HttpPost]
        public PartialViewResult Login(string email)
        {
            if (ContactRepository.EmailAlreadyExists(email))
            {
                SessionHelper.GetInstance().CurrentUser = ContactRepository.GetByEmail(email);
                return GoTorendezVousPage();
            }

            ViewBag.Errors = LoginResource.UnknownEmail;
            return PartialView("Index", email);
        }

        [HttpPost]
        public PartialViewResult SignIn(Contact contact)
        {
            if (!ContactRepository.EmailAlreadyExists(contact.Mail))
            {
                contact.Profiles = new List<Profile>() { ProfileRepository.GetByName(Constants.GetInstance().PatientProfile) };
                ContactRepository.Save(contact);
                SessionHelper.GetInstance().CurrentUser = contact;
                return GoTorendezVousPage();
            }
            ViewBag.SignInError = SignInResource.EmailAlreadyExists;
            return PartialView("SignIn", contact);
        }


        [HttpPost]
        public PartialViewResult LoginWithFacebook(string id, string mail, string name)
        {
            return SocialNetworkLogin(id, mail, name, Constants.GetInstance().FacebookNetwork);
        }
        
        [HttpPost]
        public PartialViewResult LoginWithGoogle(string id, string mail, string name)
        {
            return SocialNetworkLogin(id, mail, name, Constants.GetInstance().GoogleNetwork);
        }

        private PartialViewResult SocialNetworkLogin(string id, string mail, string name, string networkType)
        {
            if (ContactRepository.SocialNetworkEmailAlreadyExists(mail, id, networkType))
            {
                SessionHelper.GetInstance().CurrentUser = ContactRepository.GetBySocialNetworkEmail(mail, id, networkType);
                return GoTorendezVousPage();
            }
            Contact contact = new Contact
            {
                Mail = mail,
                FullName = name,
                NetworkType = networkType,
                NetworkId = id
            };
            return PartialView("PhoneSubscription", contact);
        }

        public PartialViewResult PhoneSubscription(Contact contact)
        {
            contact.Profiles = new List<Profile>(){ ProfileRepository.GetByName(Constants.GetInstance().PatientProfile) };
            ContactRepository.Save(contact);
            SessionHelper.GetInstance().CurrentUser = contact;
            return GoTorendezVousPage();
        }
    }
}