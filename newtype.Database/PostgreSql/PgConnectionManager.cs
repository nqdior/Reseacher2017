using System.Data.SqlClient;
using newtype.Common;
using System.Collections.Generic;
using Npgsql;

namespace newtype.Database
{
    public class PgConnection
    {
        public NpgsqlConnectionStringBuilder Server = new NpgsqlConnectionStringBuilder();

        public string ConnectionString
        {
            get { return Server.ConnectionString; }
            set { Server.ConnectionString = value; }
        }

        public string dataSource
        {
            get { return Server.Host; }
            set { Server.Host = value; }
        }

        public string catalog
        {
            get { return Server.Database; }
            set { Server.Database = value; }
        }

        public string id
        {
            get { return Server.Username; }
            set { Server.Username = value; }
        }

        public string password
        {
            get { return Server.Password; }
            set { Server.Password = value; }
        }

        public bool security
        {
            get { return Server.IntegratedSecurity; }
            set { Server.IntegratedSecurity = value; }
        }

        public new string ToString
        {
            get { return Server.ConnectionString; }
        }        

        public PgConnection()
        {
            XmlManager xml = new XmlManager();
            ConnectionString = EncryptService.DecryptString(xml[new List<string>() { "pgserver" }]);
        }

        public bool Save()
        {
            try
            {
                var xml = new XmlManager(false);
                xml[new List<string>() { "pgserver" }] = EncryptService.EncryptString(ConnectionString);

                xml.Save();
                xml.Dispose();

                return true;
            }
            catch { return false; }
        }
    }
}
