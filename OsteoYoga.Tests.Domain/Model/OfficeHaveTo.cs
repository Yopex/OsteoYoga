﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OsteoYoga.Domain.Models;

namespace OsteoYoga.Tests.Domain.Model
{
    [TestClass]
    public class OfficeHaveTo
    {

        const string Name = "name";
        readonly IList<Duration> durations = new List<Duration>();

        [TestMethod]
        public void InitializeCorrectlyInitialize()
        {
            Office office = new Office
            {
                Name = Name,
                Durations = durations
            };
            Assert.AreEqual(Name, office.Name);
        }
    }
}
