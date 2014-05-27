using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    public class DefaultModuleRepository : BaseRepository
    {
        /// <summary>
        /// 標準モジュールマスタのレコード全件を取得する.
        /// </summary>
        /// <returns>シリーズマスタのレコード全件</returns>
        public List<DefaultModule> FindAll()
        {            
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_DEFAULT_MODULE";

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
        private List<DefaultModule> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<DefaultModule> defaultModules = new List<DefaultModule>();

            while (sqliteDataReader.Read())
            {
                DefaultModule defaultModule = new DefaultModule();

                defaultModule.id = dataReader["MODULE_ID"].ToString();
                defaultModule.moduleTypeId = dataReader["MODULE_TYPE_ID"].ToString();
                defaultModule.rectangle = dataReader["RECT_FLG"].ToString();
                defaultModule.widthSize1 = double.Parse(dataReader["WIDTH_SIZE1"].ToString());
                defaultModule.widthSize2 = double.Parse(dataReader["WIDTH_SIZE2"].ToString());
                defaultModule.heightSize1 = double.Parse(dataReader["HEIGHT_SIZE1"].ToString());
                defaultModule.heightSize2 = double.Parse(dataReader["HEIGHT_SIZE2"].ToString());
                defaultModule.lowVirticalSize = double.Parse(dataReader["LOW_VIR_SIZE"].ToString());
                defaultModule.highVirticalSize = double.Parse(dataReader["HI_VIR_SIZE"].ToString());
                defaultModule.direction = dataReader["DIRECTION"].ToString();

                defaultModules.Add(defaultModule);
            }
            return defaultModules;

        }
    }
}
