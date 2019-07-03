using System.Data.SqlClient;
using newtype.Common;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace newtype.Database
{
    public class MyConnection
    {
        public MySqlConnectionStringBuilder Server = new MySqlConnectionStringBuilder();

        public string ConnectionString
        {
            get { return Server.ConnectionString; }
            set { Server.ConnectionString = value; }
        }

        public string dataSource
        {
            get { return Server.Server; }
            set { Server.Server = value; }
        }

        public string catalog
        {
            get { return Server.Database; }
            set { Server.Database = value; }
        }

        public string id
        {
            get { return Server.UserID; }
            set { Server.UserID = value; }
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

        public MyConnection(bool dispose = true)
        {
            XmlManager xml = new XmlManager(dispose);
            ConnectionString = EncryptService.DecryptString(xml[new List<string>() { "myserver" }]);
        }

        public bool Save()
        {
            try
            {
                var xml = new XmlManager(false);
                xml[new List<string>() { "myserver" }] = EncryptService.EncryptString(ConnectionString);

                xml.Save();
                xml.Dispose();

                return true;
            }
            catch { return false; }
        }
    }
}
