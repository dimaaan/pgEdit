using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class Column
    {
        public string Name { get; set; }
        public string PgType { get; set; }
        public bool NotNull { get; set; }
        public bool PrimaryKey { get; set; }
        public bool ForeignKey { get; set; }
        public bool Unique { get; set; }
        public object DefaultValue { get; set; }
        public string Description { get; set; }
    }
}
