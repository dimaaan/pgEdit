using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgEdit.GridFilter
{
    /// <summary>
    /// Implemented by all filter forms
    /// </summary>
    public interface IFIlterForm
    {
        /// <summary>
        /// DataColunm.Expression for selected filter
        /// </summary>
        string Filter { get; }
    }
}
