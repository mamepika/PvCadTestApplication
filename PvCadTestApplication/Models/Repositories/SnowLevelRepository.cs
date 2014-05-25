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
    /// 積雪レベル用リポジトリ実装クラス
    /// </summary>
    public class SnowLevelRepository : BaseRepository
    {
        /// <summary>
        /// 積雪レベルマスタのレコード全件を取得する.
        /// </summary>
        /// <returns>シリーズマスタのレコード全件</returns>
        public List<SnowLevel> FindAll()
        {
            
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_SNOW_LV;";

                    using (dataReader = command.ExecuteReader())
                    {
                        return ReaderToList(dataReader);
                    }
                }
            }
        }

        /// <summary>
        /// SQLite.DataReaderをList形式に変換する
        /// </summary>
        /// <param name="sqliteDataReader"></param>
        /// <returns></returns>
        private List<SnowLevel> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<SnowLevel> snowLevels = new List<SnowLevel>();

            while (sqliteDataReader.Read())
            {
                SnowLevel snow = new SnowLevel();

                snow.id = sqliteDataReader["SNOW_LV_ID"].ToString();
                snow.name = sqliteDataReader["SNOW_LV_NAME"].ToString();
                snowLevels.Add(snow);
            }
            return snowLevels;
        }
    }
}
