using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simetry.Interface.Serialization
{
    /// <summary>
    /// implement this interface in classes handling adding of form value class
    /// </summary>
    public interface IFormAdder
    {
        void AddFormValue(FormValue value);
    }
}
