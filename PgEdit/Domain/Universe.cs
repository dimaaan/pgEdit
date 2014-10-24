using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.Domain
{
    public class Universe
    {
        public Universe()
        {
            Servers = new List<Server>();
        }

        /// <summary>
        /// Can't be null
        /// </summary>
        public List<Server> Servers { get; set; }
    }
}
