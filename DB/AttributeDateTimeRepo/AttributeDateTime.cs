using DB.AttributeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.AttributeDateTimeRepo
{
    public class AttributeDateTime : BaseAttributes
    {
        public DateTime Value { get; set; }
    }
}
