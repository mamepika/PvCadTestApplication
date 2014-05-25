using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PvCadTestApplication.Models.Entities;
using System.Data.SQLite;

namespace PvCadTestApplication.Models.Repositories
{
    /// <summary>
    /// シリーズマスタ用リポジトリクラス
    /// </summary>
    public class SeriesRepository : BaseRepository
    {
        /// <summary>
        /// シリーズマスタのレコード全件を取得する.
        /// </summary>
        /// <returns>シリーズマスタのレコード全件</returns>
        public List<Series> FindAll()
        {
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_SERIES;";
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
        private List<Series> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<Series> serieses = new List<Series>();

            while (sqliteDataReader.Read())
            {
                Series series = new Series();
                series.id = sqliteDataReader["SERIES_ID"].ToString();
                series.roofTypeId = sqliteDataReader["ROOF_TYPE_ID"].ToString();
                series.name = sqliteDataReader["SERIES_NAME"].ToString();
                serieses.Add(series);
            }
            return serieses;
        }
    }
}
