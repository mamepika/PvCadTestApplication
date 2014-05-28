using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PvCadTestApplication.Models.Entities;
using PvCadTestApplication.Models.Repositories;

namespace PvCadTestApplication.Models.Services
{
    class ModuleSeriesCheckService
    {
        private List<RoofMaterial> roofMaterials;

        private List<SupportMaterial> supportMaterials;

        private List<WorkLevel> workLevels;

        public ModuleSeriesCheckService()
        {
            RoofMaterialRepository roofRepository = new RoofMaterialRepository();
            roofMaterials = roofRepository.FindAll();

            SupportMaterialRepository supportRepository = new SupportMaterialRepository();
            supportMaterials = supportRepository.FindAll();

            WorkLevelRepository workRepository = new WorkLevelRepository();
            workLevels = workRepository.FindAll();
        }

        public void Check()
        {
            for (int i = 0; i < roofMaterials.Count(); i++)
            {
                for (int j = 0; j < supportMaterials.Count(); j++)
                {
                    for (int k = 0; k < workLevels.Count(); k++)
                    {

                    }
                }
            }
        }
    }
}
