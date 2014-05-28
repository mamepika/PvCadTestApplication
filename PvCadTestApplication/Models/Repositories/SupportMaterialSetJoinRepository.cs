using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    class SupportMaterialSetJoinRepository :BaseRepository
    {
        public List<string> FindBySupportMaterialSetId(string supportMaterialSetId)
        {
            List<string> supportMaterials = new List<string>();
            using(connection  = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT SUPPORT_MAT_ID FROM M_SUPPORT_MAT_SET_JOIN "
                                                           + "WHERE SUPPORT_MAT_SET_ID = '" + supportMaterialSetId + "'";
                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            supportMaterials.Add(dataReader["SUPPORT_MAT_ID"].ToString());
                        }                        
                    }
                }
            }
            return supportMaterials;
        }
    }
}
