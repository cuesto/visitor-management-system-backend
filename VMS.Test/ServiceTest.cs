using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VMS.Utils;

namespace VMS.Test
{
    [TestClass]
    public class ServiceTest
    {
        [TestMethod]
        public void ValidateRNCOrCedulaOnDGII()
        {
            string nombre = "JHONATAN LOAMMY CUESTO GUILLEN";
            var rnc = DGII.ConsultarRNC("40220097683");

            Assert.AreEqual(rnc.Nombre, nombre);
        }
    }
}
