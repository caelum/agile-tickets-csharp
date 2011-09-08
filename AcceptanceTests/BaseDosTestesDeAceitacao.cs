using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace AcceptanceTests
{
    public class BaseDosTestesDeAceitacao
    {
        protected DefaultSelenium browser;

        [SetUp]
        public void SetUp()
        {
            browser = new DefaultSelenium("localhost", 4444, "*firefox", "http://localhost:49278");
            browser.Start();
        }

        [TearDown]
        public void TearDown()
        {
            browser.Stop();
        }

    }
}
