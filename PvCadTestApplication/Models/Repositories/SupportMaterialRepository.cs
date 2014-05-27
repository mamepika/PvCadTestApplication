using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;

namespace PvCadTestApplication.Models.Repositories
{
    class SupportMaterialRepository : BaseRepository
    {
        public List<SupportMaterial> FindAll()
        {
            using (connection = new SQLiteConnection("Data Source =" + databaseFile))
            {
                connection.Open();
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM M_ROOF_MAT";
                    using (dataReader = command.ExecuteReader())
                    {
                        return ReaderToList(dataReader);
                    }
                }
            }
        }

        private List<SupportMaterial> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<SupportMaterial> supportMaterials = new List<SupportMaterial>();

            while (sqliteDataReader.Read())
            {
                SupportMaterial supportMaterial = new SupportMaterial();

                supportMaterial.id = dataReader["SUPPORT_MAT_ID"].ToString();
                supportMaterial.name = dataReader["SUPPORT_MAT_NAME"].ToString();


                supportMaterials.Add(supportMaterial);
            }
            return supportMaterials;
        }
    }
}
