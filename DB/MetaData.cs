using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Metadata
    {
        public int MetadataId { get; set; }
        public int AttributeId { get; set; }
        public string DataType { get; set; }
        public bool IsRequired { get; set; }
        public string Format { get; set; }
        public bool IsSearchable { get; set; }
    }
}
