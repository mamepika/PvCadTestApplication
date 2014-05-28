using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    class WorkLevelRepository : BaseRepository
    {
        public List<WorkLevel> FindAll()
        {
            List<WorkLevel> windLevels = new List<WorkLevel>();
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_WORK_LV;";

                    using (dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            WorkLevel workLevel = new WorkLevel();
                            workLevel.workLevelId = dataReader["WIND_LV_ID"].ToString();
                            workLevel.workLevelName = dataReader["WIND_LV_NAME"].ToString();
                            windLevels.Add(workLevel);
                        }
                    }
                }
            }
            return windLevels;
        }
    }
}
