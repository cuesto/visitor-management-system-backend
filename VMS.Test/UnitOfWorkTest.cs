using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Threading;
using VMS.DataModel.DAL;

namespace VMS.Test
{
    [TestClass]
    public class UnitOfWorkTest
    {
        private UnitOfWork uow;
        private Mock<MyDbContext> dbContextMock;

        [TestInitialize]
        public void TestInitialize()
        {
            dbContextMock = new Mock<MyDbContext>();
            uow = new UnitOfWork(dbContextMock.Object);
        }

        [TestMethod]
        public void ShouldSave()
        {
            dbContextMock.Setup(x => x.SaveChanges()).Returns(1);
            var result = uow.Save();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ShouldSaveAsync()
        {
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            var result = uow.SaveAsync();

            Assert.AreEqual(1, result.Result);
        }

        [TestMethod]
        public void ShouldNotSave()
        {
            dbContextMock.Setup(x => x.SaveChanges()).Returns(0);
            var result = uow.Save();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldNotSaveAsync()
        {
            dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            var result = uow.SaveAsync();

            Assert.AreEqual(0, result.Result);
        }

    }
}
