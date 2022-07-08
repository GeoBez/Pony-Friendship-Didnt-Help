using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AddPower : CardUpgrade
    {
        public override Card Card => new Card("Силушка", "Увеличивает урон на 5 едениц");

        protected override void Function()
        {
            Player.MainPlayer.ChangeDamage(5F);
        }
    }
}
