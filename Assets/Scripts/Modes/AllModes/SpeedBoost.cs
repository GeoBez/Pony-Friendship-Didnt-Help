using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class SpeedBoost : CardUpgrade
    {
        public override Card Card => new Card("Золотые подковы", "Увеличение скорости на 20%");

        protected override void Function()
        {
            Player.MainPlayer.Speed += Player.MainPlayer.Speed * 0.2F;
        }
    }
}
