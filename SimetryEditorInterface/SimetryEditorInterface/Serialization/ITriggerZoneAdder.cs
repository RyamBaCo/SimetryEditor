using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Globals;

namespace Simetry.Interface.Serialization
{
    /// <summary>
    /// implement this interface in classes handling adding of trigger zone class
    /// </summary>
    public interface ITriggerZoneAdder
    {
        void AddTriggerZone(TriggerZoneValue value);
    }
}
