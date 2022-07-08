using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AttackRadius : CardUpgrade
    {
        public override Card Card => new Card("Это же... МАГИЯ!", "Дает возможность колдовать");

        protected override void Function()
        {
            Player.MainPlayer.Weapon.enabled = true;
        }
    }
}
