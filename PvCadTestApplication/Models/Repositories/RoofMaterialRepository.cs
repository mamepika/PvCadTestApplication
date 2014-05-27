using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using PvCadTestApplication.Models.Entities;


namespace PvCadTestApplication.Models.Repositories
{
    class RoofMaterialRepository : BaseRepository
    {
        public List<RoofMaterial> FindAll()
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

        private List<RoofMaterial> ReaderToList(SQLiteDataReader sqliteDataReader)
        {
            List<RoofMaterial> roofMaterials = new List<RoofMaterial>();

            while(sqliteDataReader.Read())
            {
                RoofMaterial roofMaterial = new RoofMaterial();

                roofMaterial.id = dataReader["ROOF_MAT_ID"].ToString();
                roofMaterial.name = dataReader["ROOF_MAT_NAME"].ToString();
                roofMaterial.supportMaterialSetId = dataReader["SUPPORT_MAT_SET_ID"].ToString();

                roofMaterials.Add(roofMaterial);
            }
            return roofMaterials;
        }
    }
}
