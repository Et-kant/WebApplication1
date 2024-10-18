
using MySqlConnector;

namespace WebApplication1.Services
{
    public class DBaccess
    {
        private string _Stringdeconexion;

        public DBaccess(string Stringdeconexion)
        {
            this._Stringdeconexion = Stringdeconexion;
        }

        public string GetSqlconexion()
        {
            return _Stringdeconexion;
        }
    }
}
