using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexWorkShop.Core.BaseModel
{
    public interface IBase
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
    public class Base : IBase
    {
        public virtual int Id { get; set; }
        public virtual bool Deleted { get; set; }
    }
}
