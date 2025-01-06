using DB.AttributeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.AttributeValueDecimalRepo
{
    public class AttributeValueDecimal : BaseAttributes
    {
        public decimal Value { get; set; }
    }
}
