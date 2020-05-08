using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.Web.Controllers;

namespace VMS.Test
{
    [TestClass]
    public class RolesTest
    {
        private Mock<RolesController> rolesControllerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            rolesControllerMock = new Mock<RolesController>();

        }
    }
}
