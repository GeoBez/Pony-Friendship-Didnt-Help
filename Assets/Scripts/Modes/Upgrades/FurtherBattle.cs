using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class FurtherBattle : CardUpgrade
    {
        public override Card Card => new Card("У меня длиннее", "Увеличивает дальность ближнего боя");

        protected override void Function()
        {
            Player.MainPlayer.PlayerMelee.attackRange += 3;
        }
    }
}
