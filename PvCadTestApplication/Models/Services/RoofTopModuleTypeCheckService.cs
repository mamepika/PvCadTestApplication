using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PvCadTestApplication.Models.Entities;
using PvCadTestApplication.Models.Repositories;


namespace PvCadTestApplication.Models.Services
{
    /// <summary>
    /// 陸屋根のモジュールタイプ設定をチェックするサービスクラス
    /// </summary>
    public class RoofTopModuleTypeCheckService
    {
        //風速レベル
        private List<WindLevel> windLevels;
        //積雪レベル
        private List<SnowLevel> snowLevels;
        //モジュール傾斜角度
        private List<ModuleAngle> moduleAngles;
        //モジュール設置段数
        private List<string> moduleCount = new List<string> { "VERTICAL_COUNT_3", "VERTICAL_COUNT_4" };
        //設置高さ
        private List<int> foundationHeight = new List<int>{ 0, 1 };
        private Encoding encode = System.Text.Encoding.GetEncoding("shift_jis");

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RoofTopModuleTypeCheckService()
        {
            WindLevelRepository windLevelRepository = new WindLevelRepository();
            this.windLevels = windLevelRepository.FindAll();

            SnowLevelRepository snowRepository = new SnowLevelRepository();
            this.snowLevels = snowRepository.FindAll();

            RoofTopModuleAngleRepository moduleAngleRepository = new RoofTopModuleAngleRepository();
            this.moduleAngles = moduleAngleRepository.FindAll();

        }
        /// <summary>
        /// 
        /// </summary>
        public void Check()
        {
            using (StreamWriter streamWriter = new StreamWriter("C:\\work\\RoofTopModuleType.txt", false,encode))
            {
                RoofTopModuleSelectRepository moduleSelectRepository = new RoofTopModuleSelectRepository();
                for (int i = 0; i < foundationHeight.Count(); i++)
                {
                    streamWriter.WriteLine(foundationHeight[i].ToString());
                    for (int j = 0; j < windLevels.Count(); j++)
                    {
                        streamWriter.WriteLine("\t" + windLevels[j].windLevelId);
                        for (int k = 0; k < snowLevels.Count(); k++)
                        {
                            streamWriter.WriteLine("\t" + "\t" + snowLevels[k].id);

                            for (int l = 0; l < moduleAngles.Count(); l++)
                            {
                                streamWriter.Write("\t" + "\t" + "\t" + moduleAngles[l].id);
                                for (int m = 0; m < moduleCount.Count(); m++) {
                                    string recordExitsts =
                                        moduleSelectRepository.FindByCondition(foundationHeight[i], snowLevels[k].id, windLevels[j].windLevelId,moduleCount[m], moduleAngles[l].id) ? "○" : "×";
                                    if (m == 0)
                                    {
                                        streamWriter.Write("\t" + moduleCount[m] + "\t" + recordExitsts);
                                    }
                                    else
                                    {
                                        streamWriter.Write("\t" + "\t" + "\t" + "\t" + moduleCount[m] + "\t" + recordExitsts);
                                    }
                                    streamWriter.WriteLine();
                                }
                            }
                        }
                     }
                }
            }
        }
    }
}
