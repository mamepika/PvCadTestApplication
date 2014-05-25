using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace PvCadTestApplication.Models.Repositories
{
    /// <summary>
    /// リポジトリの基底クラス
    /// </summary>
    public class BaseRepository
    {
        protected SQLiteConnection connection;

        protected SQLiteCommand command;

        protected SQLiteDataReader dataReader;

        protected string databaseFile = "pvMst.db";

        public BaseRepository()
        {
            
        }
    }
}
