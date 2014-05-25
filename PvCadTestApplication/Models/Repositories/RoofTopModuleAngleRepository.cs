using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    /// <summary>
    /// 陸屋根モジュール傾斜角度マスタリポジトリ実装クラス
    /// </summary>
    public class RoofTopModuleAngleRepository : BaseRepository
    {

        /// <summary>
        /// 陸屋根モジュール傾斜角度マスタのレコード全件を取得する.
        /// </summary>
        /// <returns>陸屋根モジュール傾斜角度マスタのレコード全件</returns>
        public List<ModuleAngle> FindAll()
        {
           
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using(command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_ROOFTOP_MODULE_ANGLE;";
                    using(dataReader = command.ExecuteReader())
                    {
                        return ReaderToList(dataReader);
                    }
                }
            }
        }


        private List<ModuleAngle> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<ModuleAngle> moduleAngles = new List<ModuleAngle>();
            while (sqliteDataReader.Read())
            {
                ModuleAngle moduleAngle = new ModuleAngle();

                moduleAngle.id = dataReader["MODULE_ANGLE_ID"].ToString();
                moduleAngle.name = dataReader["MODULE_ANGLE_NAME"].ToString();
                moduleAngle.value = int.Parse(dataReader["MODULE_ANGLE_VALUE"].ToString());

                moduleAngles.Add(moduleAngle);
            }
            return moduleAngles;
        }
    }
}
