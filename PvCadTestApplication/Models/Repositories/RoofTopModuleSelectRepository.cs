using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PvCadTestApplication.Models.Repositories
{
    class RoofTopModuleSelectRepository : BaseRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundationHeight"></param>
        /// <param name="snowLevel"></param>
        /// <param name="windLevel"></param>
        /// <param name="moduleAngleId"></param>
        /// <returns></returns>
        public bool FindByCondition(int foundationHeight, 
                                                 string snowLevel,
                                                 string windLevel, 
                                                 string moduleCount,                                    
                                                 string moduleAngleId)
        {
            using(connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using(command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT DISTINCT M_ROOFTOP_MODULE_COUNT.MODULE_COUNT_ID AS MODULE_COUNT_ID, MODULE_COUNT_NAME, "
                                                               + "MODULE_ANGLE_ID, WIND_LV_ID, SNOW_LV_ID, SUPPORT_MAT_ID,M_ROOFTOP_MODULE_SELECT.MODULE_ID "
                                                               + "FROM M_ROOFTOP_MODULE_SELECT "
                                                               + "LEFT JOIN M_ROOFTOP_MODULE_JOIN ON M_ROOFTOP_MODULE_SELECT.MODULE_ID = M_ROOFTOP_MODULE_JOIN.MODULE_ID "
                                                               + "LEFT JOIN M_ROOFTOP_MODULE_COUNT ON M_ROOFTOP_MODULE_JOIN.MODULE_COUNT_ID = M_ROOFTOP_MODULE_COUNT.MODULE_COUNT_ID "
                                                               + "WHERE WIND_LV_ID = '" + windLevel + "' "
                                                               + "AND SNOW_LV_ID = '" + snowLevel + "' "
                                                               + "AND M_ROOFTOP_MODULE_SELECT.MIN_HEIGHT = " + foundationHeight.ToString() + " "
                                                               + "AND M_ROOFTOP_MODULE_COUNT.MODULE_COUNT_ID = '" + moduleCount + "' "
                                                               + "AND MODULE_ANGLE_ID = '" + moduleAngleId + "';";
                    using(dataReader = command.ExecuteReader())
                    {
                        return dataReader.HasRows;
                    }
                }
            }
        }
    }
}
