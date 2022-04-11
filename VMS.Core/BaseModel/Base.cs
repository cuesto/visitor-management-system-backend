using System.ComponentModel;

namespace VMS.Core.BaseModel
{

    public interface IBase
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }

    public class Base : IBase
    {
        public virtual int Id { get; set; }
        [DefaultValue(false)]
        public virtual bool Deleted { get; set; }
    }


}