using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simetry.Interface.Globals;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Xna.Framework;
using Simetry.Interface.Serialization;

namespace Simetry.Interface.Actions
{
    public partial class ActionAllow : BaseAction
    {
        public bool Allow { get; private set; }

        public ActionAllow(bool executeOnEnter, bool executeOnExit, bool executeOnKey, string parameters)
            :   base(executeOnEnter, executeOnExit, executeOnKey)
        {
            using (TextReader stringReader = new StringReader(parameters))
            using (JsonReader reader = new JsonTextReader(stringReader))
            {
                JObject actionValue = JObject.Load(reader);
                JToken actionToken = actionValue.First;

                while (actionToken != null)
                {
                    JProperty actionProperty = (JProperty)actionToken;
                    switch (actionProperty.Name)
                    {
                        case SerializationConstants.JSON_PROPERTY_ACTION_PROPERTY_ALLOW:
                            Allow = Convert.ToBoolean(actionProperty.Value);
                        break;
                    }
                    actionToken = actionToken.Next;
                }
            }
        }
    }
}
