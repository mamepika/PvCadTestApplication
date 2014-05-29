using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PvCadTestApplication.Models.Entities;
using PvCadTestApplication.Models.Repositories;

namespace PvCadTestApplication.Models.Services
{
    /// <summary>
    /// 施工レベル絞り込みマスタのチェック
    /// </summary>
    class WorkLevelSelectCheckService
    {
        //屋根材
        private List<RoofMaterial> roofMaterials;
        //風速レベル
        private List<WindLevel> windLevels;
        //積雪レベル
        private List<SnowLevel> snowLevels;

        public WorkLevelSelectCheckService()
        {
            RoofMaterialRepository roofRepository = new RoofMaterialRepository();
            roofMaterials = roofRepository.FindAll();

            WindLevelRepository windLevelRepository = new WindLevelRepository();
            this.windLevels = windLevelRepository.FindAll();

            SnowLevelRepository snowRepository = new SnowLevelRepository();
            this.snowLevels = snowRepository.FindAll();
        }


        public void Check()
        {
            for (int i = 0; i < roofMaterials.Count(); i++)
            {
                for (int j = 0; j < roofMaterials[i].supportMaterials.Count(); j++)
                {
                    for (int k = 0; k<windLevels.Count(); k++)
                    {
                        for (int l = 0; l < snowLevels.Count(); l++)
                        {

                        }
                    }
                }
            }
        }
    }
}
