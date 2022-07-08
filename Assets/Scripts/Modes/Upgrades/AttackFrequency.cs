using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AttackFrequency : CardUpgrade
    {
        public override Card Card => new Card("Легкость", "Увеличивает скорость атаки на 50%");

        protected override void Function()
        {
            Player.MainPlayer.PlayerMelee.attackCoolDown /= 2;
        }
    }
}
