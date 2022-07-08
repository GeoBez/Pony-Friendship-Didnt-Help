using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class DoublPower : CardUpgrade
    {
        public override Card Card => new Card("Сила есть, ума не надо", "Увеличивают урон на 100%");

        protected override void Function()
        {
            Player.MainPlayer.AddDamage(Player.MainPlayer.Damage);
        }
    }
}
