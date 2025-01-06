using DB.AttributeRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.AttributeValueVarcharRepo
{
    public class AttributeValueVarchar : BaseAttributes
    {
        [MaxLength(200)]
        public string Value { get; set; }
    }
}
