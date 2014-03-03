using PgEdit.Domain;
using System.IO;
using System.Web.Script.Serialization;

namespace PgEdit.Service
{
    class ConnectionService
    {
        public static Universe Load()
        {
            const string CONNECTION_STRINGS_PATH = "ConnectionStrings.json";
            Universe universe = new Universe();

            if (File.Exists(CONNECTION_STRINGS_PATH))
            {
                universe = (new JavaScriptSerializer()).Deserialize<Universe>(File.ReadAllText(CONNECTION_STRINGS_PATH));
            }

            return universe;
        }
    }
}
