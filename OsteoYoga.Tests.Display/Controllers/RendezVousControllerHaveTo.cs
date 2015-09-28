﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Calendar.v3.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using OsteoYoga.Domain.Models;
using OsteoYoga.Helper;
using OsteoYoga.Helper.Helpers.Implements;
using OsteoYoga.Helper.Helpers.Interfaces;
using OsteoYoga.Repository.DAO.Abstracts;
using OsteoYoga.Repository.DAO.Implements;
using OsteoYoga.Repository.DAO.Interfaces;
using OsteoYoga.Site.Controllers;
using OsteoYoga.Site.ViewResults;

namespace OsteoYoga.Tests.Display.Controllers
{
    [TestClass]
    public class RendezVousControllerHaveTo
    {
        private const string ServerAddress = "http://osteoyoga.fr";
        private readonly Patient patient = new Patient();
        private readonly Mock<SessionHelper> sessionHelperMock = new Mock<SessionHelper>();
        private readonly Mock<IOfficeRepository> officeRepositoryMock = new Mock<IOfficeRepository>();
        private readonly Mock<IPratictionerOfficeRepository> pratictionerOfficeRepositoryMock = new Mock<IPratictionerOfficeRepository>();
        private readonly Mock<IDaySlotHelper> freeSlotHelperMock = new Mock<IDaySlotHelper>();

        private readonly IList<Office> offices = new List<Office>();

        private readonly Mock<Email> emailMock = new Mock<Email>();
        private readonly Mock<Constants> constantsMock = new Mock<Constants>();
        private RendezVousController Controller { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Controller = new RendezVousController
            {
                OfficeRepository = officeRepositoryMock.Object,
                PratictionerOfficeRepository = pratictionerOfficeRepositoryMock.Object,
                DaySlotHelper = freeSlotHelperMock.Object
                //GoogleRepository = googleRepositoryMock.Object,
                //DurationRepository = durationRepositoryMock.Object,
            };
            SessionHelper.Instance = sessionHelperMock.Object;
            sessionHelperMock.Setup(shm => shm.CurrentUser).Returns(patient);
            Email.Instance = emailMock.Object;
            Constants.Instance = constantsMock.Object;
            constantsMock.Setup(cm => cm.ServerAddress(It.IsAny<HttpRequestBase>())).Returns(ServerAddress);
        }


        [TestMethod]
        public void CorrectlyInitialize()
        {
            RendezVousController controller = new RendezVousController();

            //Assert.IsInstanceOfType(controller.DurationRepository, typeof(DurationRepository));
            Assert.IsInstanceOfType(controller.OfficeRepository, typeof(OfficeRepository));
            Assert.IsInstanceOfType(controller.PratictionerOfficeRepository, typeof(PratictionerOfficeRepository));
            Assert.IsInstanceOfType(controller.GoogleRepository, typeof(GoogleRepository));
            Assert.IsInstanceOfType(controller.DaySlotHelper, typeof(DaySlotHelper));

        }

        [TestMethod]
        public void GoToIndexPageWithParameter()
        {
            //arrange
            officeRepositoryMock.Setup(orm => orm.GetAll()).Returns(offices);
            
            //act
            PartialViewResult result = Controller.Index();

            //assert
            Assert.AreEqual(offices, ((DateViewResult)result.Model).Offices );
            Assert.AreEqual("Index", result.ViewName);
        }


        [TestMethod]
        public void Return_Pratictioners_By_Office_Id()
        {
            //arrange
            int officeId = 1;
            Pratictioner expectedPratictioner1 = new Pratictioner() {Id = 1, FullName = "FullName1"};
            Pratictioner expectedPratictioner2 = new Pratictioner() { Id = 2, FullName = "FullName2" };
            Office expectedOffice = new Office()
            {
                Pratictioners = new List<Pratictioner>()
                {
                    expectedPratictioner1,
                    expectedPratictioner2
                }
            };
            officeRepositoryMock.Setup(r => r.GetById(officeId)).Returns(expectedOffice);

            //act
            JsonResult result = Controller.Pratictioners(officeId);
    
            //assert     
            IList<DropDowJsonViewResult> data = (IList<DropDowJsonViewResult>) result.Data;
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(1, data[0].Id);
            Assert.AreEqual("FullName1", data[0].Name);
            Assert.AreEqual(2, data[1].Id);
            Assert.AreEqual("FullName2", data[1].Name);
        }



        [TestMethod]
        public void Return_Duration_By_Office_And_Pratictioner_Id()
        {
            //arrange
            const int officeId = 1;
            const int pratictionerId = 2;
            Duration duration1 = new Duration() { Id = 3, Value = 30 };
            Duration duration2 = new Duration() { Id = 4, Value = 45 };


            Office expectedOffice = new Office() { Id = officeId };
            Pratictioner expectedPratictioner = new Pratictioner() { Id = pratictionerId };

            PratictionerOffice pratictionerOffices = new PratictionerOffice()
            {
                Office = expectedOffice,
                Pratictioner = expectedPratictioner,
                Durations = new List<Duration>() {duration1, duration2}
            };

            pratictionerOfficeRepositoryMock.Setup(r => r.GetByOfficeIdAndPratictionerId(officeId, pratictionerId)).Returns(pratictionerOffices);

            //act
            JsonResult result = Controller.Durations(officeId, pratictionerId);

            //assert     
            IList<DropDowJsonViewResult> data = (IList<DropDowJsonViewResult>)result.Data;
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(3, data[0].Id);
            Assert.AreEqual("30", data[0].Name);
            Assert.AreEqual(4, data[1].Id);
            Assert.AreEqual("45", data[1].Name);
        }

        [TestMethod]
        public void Return_Free_Days_By_Office_And_Pratictioner_And_Duration_Id()
        {
            //arrange
            const int officeId = 1;
            const int pratictionerId = 2;
            const int durationId = 3;
            DateTime day1 = new DateTime();
            DateTime day2 = new DateTime();
            Office expectedOffice = new Office() { Id = officeId };
            Pratictioner expectedPratictioner = new Pratictioner() { Id = pratictionerId };
            Duration expectedDuration = new Duration() { Id = durationId, Value = 45};

            PratictionerOffice pratictionerOffices = new PratictionerOffice()
            {
                Office = expectedOffice,
                Pratictioner = expectedPratictioner,
                Durations = new List<Duration>() { expectedDuration }
            };

            pratictionerOfficeRepositoryMock.Setup(r => r.GetByOfficeIdAndPratictionerId(officeId, pratictionerId)).Returns(pratictionerOffices);
            freeSlotHelperMock.Setup(r => r.CalculateFreeDays(pratictionerOffices, expectedDuration)).Returns(new List<DateTime>() {day1,day2});

            //act
            JsonResult result = Controller.FreeDays(officeId, pratictionerId, durationId);

            //assert     
            IList<FreeDayJsonViewResult> data = (IList<FreeDayJsonViewResult>)result.Data;
            Assert.AreEqual(2, data.Count);
            Assert.AreEqual(day1, data[0].FreeDay);
            Assert.AreEqual(day2, data[1].FreeDay);
        }
    }
}
