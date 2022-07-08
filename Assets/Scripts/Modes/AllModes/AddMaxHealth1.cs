using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AddMaxHealth1 : CardUpgrade
    {
        public override Card Card => new Card("Здорово, здоровье", "Увеличение количества жизни на 20 едениц");

        protected override void Function()
        {
            Player.MainPlayer.AddHealsMax(20);
        }
    }
}
