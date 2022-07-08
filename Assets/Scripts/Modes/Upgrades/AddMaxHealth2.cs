using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AddMaxHealth2 : CardUpgrade
    {
        public override Card Card => new Card("Здоровяк", "Увеличение количества жизни на 10%");

        protected override void Function()
        {
            Player.MainPlayer.AddHealsMax(Player.MainPlayer.maxHealth * 0.1F);
        }
    }
}
