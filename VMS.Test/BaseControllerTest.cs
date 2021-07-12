using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VMS.DataModel.Entities;
using VMS.DataModel.Validators;
using VMS.Web.Controllers;

namespace VMS.Test
{
    [TestClass]
    public class BaseControllerTest
    {
        private Mock<IBaseController> baseControllerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            baseControllerMock = new Mock<IBaseController>();
        }

        //[TestMethod]
        //public void ShouldUpdate()
        //{
        //    //await UpdateAsync<Role, RoleValidator>(role);


        //   // baseControllerMock.Setup(x => x.UpdateAsync<Role, RoleValidator>(new Role()));
        //}
    }
}
