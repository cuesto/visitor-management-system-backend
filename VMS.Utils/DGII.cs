using consulta_dgii_csharp;

namespace VMS.Utils
{
    public class DGII
    {
        public static ResultRnc ConsultarRNC(string rnc)
        {
            ResultRnc result = new ResultRnc();
            result = RncQueryWrapper.QueryByRnc(rnc);
            if (result.Nombre != null)
            {
                return result;
            }
            return new ResultRnc();
        }
    }
}
