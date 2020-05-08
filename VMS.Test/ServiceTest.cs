using Microsoft.VisualStudio.TestTools.UnitTesting;
using VMS.Utils;

namespace VMS.Test
{
    [TestClass]
    public class ServiceTest
    {
        [DataTestMethod]
        [DataRow("40220097683", "JHONATAN LOAMMY CUESTO GUILLEN")]
        [DataRow("131222872", "INFOSOCIAL SRL")]
        public void ValidateRNCOrCedulaOnDGII(string rnc, string name)
        {
            //string nombre = "JHONATAN LOAMMY CUESTO GUILLEN";
            var result = DGII.ConsultarRNC(rnc);

            Assert.AreEqual(result.Nombre, name);
        }
    }
}
