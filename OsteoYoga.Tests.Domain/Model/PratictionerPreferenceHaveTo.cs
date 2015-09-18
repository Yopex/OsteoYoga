﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsteoYoga.Domain.Models;
using OsteoYoga.Resource;

namespace OsteoYoga.Tests.Domain.Model
{
    [TestClass]
    public class PratictionerPreferenceHaveTo
    {
        DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        [TestMethod]
        public void InitializeCorrectlyInitialize()
        {
            Contact contact = new Contact();

            PratictionerPreference pratictionerPreference = new PratictionerPreference()
            {
               Contact = contact,
               Reminder = 30,
               DateWaiting = 50,
               MinInterval = 3,
               MaxInterval = 45,
            };

            Assert.AreEqual(contact, pratictionerPreference.Contact);
            Assert.AreEqual(30, pratictionerPreference.Reminder);
            Assert.AreEqual(50, pratictionerPreference.DateWaiting);
            Assert.AreEqual(3, pratictionerPreference.MinInterval);
            Assert.AreEqual(45, pratictionerPreference.MaxInterval);
        }

        [TestMethod]
        public void Get_Min_Date_Value_By_Min_Interval()
        {
            //arrange
            now = now.AddDays(3);

            //act
            PratictionerPreference pratictionerPreference = new PratictionerPreference(){ 
                MinInterval = 3,
            };
            
            //assert
            Assert.AreEqual(now.ToString("d"), pratictionerPreference.MinDateInterval.ToString("d"));
        }

        [TestMethod]
        public void Get_Max_Date_Value_By_Min_Interval()
        {
            //arrange
            now = now.AddDays(15);

            //act
            PratictionerPreference pratictionerPreference = new PratictionerPreference(){ 
                MaxInterval = 15,
            };
            
            //assert
            Assert.AreEqual(now.ToString("d"), pratictionerPreference.MaxDateInterval.ToString("d"));
        }

    }
}