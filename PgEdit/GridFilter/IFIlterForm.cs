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
    /// <remarks>
    /// Windows style for filters:
    /// * ShowIcon = false
    /// * ShowInTaskbar = false
    /// * Size = 382; 204
    /// * MinimizeBox = false
    /// * MaximizeBox = false
    /// * FormBorderStyle = FixedSingle
    /// </remarks>
    public interface IFIlterForm
    {
        /// <summary>
        /// DataColunm.Expression for selected filter
        /// </summary>
        string Filter { get; }
    }
}
