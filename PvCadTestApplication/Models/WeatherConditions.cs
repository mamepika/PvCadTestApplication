using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PvCadTestApplication.Models.Entities;
using PvCadTestApplication.Models.Repositories;

namespace PvCadTestApplication.Models
{
    /// <summary>
    /// 気象条件を包括するクラス
    /// </summary>
    public class WeatherConditions
    {
        private int windIndex;

        private int snowIndex;
        
        //風速レベル
        private List<WindLevel> windLevels;
        //積雪レベル
        private List<SnowLevel> snowLevels;

        public WeatherConditions()
        {
            WindLevelRepository windLevelRepository = new WindLevelRepository();
            this.windLevels = windLevelRepository.FindAll();

            SnowLevelRepository snowRepository = new SnowLevelRepository();
            this.snowLevels = snowRepository.FindAll();

            windIndex = 0;
            snowIndex = 0;
        }

        public int GetWindLevelCount()
        {
            return this.windLevels.Count();
        }

        public int GetSnowLevelCount()
        {
            return this.snowLevels.Count();
        }
    }
}
