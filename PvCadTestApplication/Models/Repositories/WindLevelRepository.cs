using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    public class WindLevelRepository : BaseRepository
    {
         public List<WindLevel> FindAll()
        {
            List<WindLevel> windLevels = new List<WindLevel>();
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand()){
                    command.CommandText = "SELECT * FROM M_WIND_LV;";

                    using(dataReader = command.ExecuteReader()){
                        while(dataReader.Read()){
                            WindLevel windLevel = new WindLevel();
                            windLevel.windLevelId = dataReader["WIND_LV_ID"].ToString();
                            windLevel.windLevelName = dataReader["WIND_LV_NAME"].ToString();
                            windLevels.Add(windLevel);
                        }                      
                    }                  
                }
            }
            return windLevels;
        }
    }
}
