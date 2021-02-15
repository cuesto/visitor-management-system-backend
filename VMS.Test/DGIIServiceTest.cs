using Microsoft.VisualStudio.TestTools.UnitTesting;
using Octetus.ConsultasDgii.ConsultasWeb;
using Octetus.ConsultasDgii.Core.Messages;
using VMS.Utils;

namespace VMS.Test
{
    [TestClass]
    public class DGIIServiceTest
    {
        [DataTestMethod]
        [DataRow("40220097683", "JHONATAN LOAMMY CUESTO GUILLEN")]
        [DataRow("131222872", "INFOSOCIAL SRL")]
        public void ValidateRNCOrCedulaOnDGII(string rnc, string name)
        {
            var dgii = new DgiiScraper();

            var response = dgii.Execute(new DgiiQueryRequest
            {
                Rnc = rnc
            });

            Assert.AreEqual(response.Nombre, name);
        }

        [DataTestMethod]
        [DataRow("131222872", "JHONATAN LOAMMY CUESTO GUILLEN")]
        public void NotValidateRNCOrCedulaOnDGII(string rnc, string name)
        {
            var dgii = new DgiiScraper();

            var response = dgii.Execute(new DgiiQueryRequest
            {
                Rnc = rnc
            });

            Assert.AreNotEqual(response.Nombre, name);
        }
    }
}
