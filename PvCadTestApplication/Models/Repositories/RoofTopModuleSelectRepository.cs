﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    class RoofTopModuleSelectRepository : BaseRepository
    {

        public List<RoofTopModuleSelect> FindAll()
        {
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT DISTINCT " +
                                                             "M_ROOFTOP_MODULE_COUNT.MODULE_COUNT_ID AS MODULE_COUNT_ID," +
                                                             "MODULE_COUNT_NAME,MODULE_ANGLE_ID,WIND_LV_ID,SNOW_LV_ID,MIN_HEIGHT,SUPPORT_MAT_ID,M_ROOFTOP_MODULE_SELECT.MODULE_ID " +
                                                             "FROM M_ROOFTOP_MODULE_SELECT " +
                                                             "LEFT JOIN " +
                                                             "M_ROOFTOP_MODULE_JOIN ON M_ROOFTOP_MODULE_SELECT.MODULE_ID = M_ROOFTOP_MODULE_JOIN.MODULE_ID " +
                                                             "LEFT JOIN " +
                                                             "M_ROOFTOP_MODULE_COUNT ON M_ROOFTOP_MODULE_JOIN.MODULE_COUNT_ID = M_ROOFTOP_MODULE_COUNT.MODULE_COUNT_ID;";
                    using (dataReader = command.ExecuteReader())
                    {
                        return ReaderToList(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// 条件に合致するレコードが存在するか
        /// </summary>
        /// <param name="foundationHeight">設置高さ</param>
        /// <param name="snowLevel">積雪レベル</param>
        /// <param name="windLevel">風速レベル</param>
        /// <param name="moduleAngleId">傾斜角</param>
        /// <returns>レコードの有無</returns>
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

        private List<RoofTopModuleSelect> ReaderToList(SQLiteDataReader sqliteDataReader){
            List<RoofTopModuleSelect> roofTopModuleSelects = new List<RoofTopModuleSelect>();

            while(sqliteDataReader.Read())
            {
                RoofTopModuleSelect roofModule = new RoofTopModuleSelect();

                roofModule.moduleCountId = sqliteDataReader["MODULE_COUNT_ID"].ToString();
                roofModule.moduleCountName = sqliteDataReader["MODULE_COUNT_NAME"].ToString();
                roofModule.moduleAngleId = sqliteDataReader["MODULE_ANGLE_ID"].ToString();
                roofModule.windLevelId = sqliteDataReader["WIND_LV_ID"].ToString();
                roofModule.snowLevelId = sqliteDataReader["SNOW_LV_ID"].ToString();
                roofModule.minimumHeight = sqliteDataReader["MIN_HEIGHT"].ToString();
                roofModule.supportMaterialId = sqliteDataReader["SUPPORT_MAT_ID"].ToString();
                roofModule.moduleId = sqliteDataReader["MODULE_ID"].ToString();

                roofTopModuleSelects.Add(roofModule);
            }
            return roofTopModuleSelects;
        }
    }
}
