using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Globalization;

namespace UberFrba
{
    class Config
    {
        public string connectionDB { get; set; }
        public DateTime date { get; set; }

        private static Config instance;

        public static Config newInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }

        private Config() {
            try
            {
                connectionDB = ConfigurationManager.ConnectionStrings["data_base_info_connection"].ConnectionString;
                date = DateTime.ParseExact(ConfigurationManager.AppSettings["system_date"], "yyyy-MM-dd", CultureInfo.InstalledUICulture);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo leer el archivo de configuracion");
            }
        }

       
    }
}
