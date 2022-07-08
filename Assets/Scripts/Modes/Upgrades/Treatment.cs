using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class Treatment : CardUpgrade
    {
        public override Card Card => new Card("Зелье исцеления", "Восстанавливает все еденицы жизни");

        protected override void Function()
        {
            Player.MainPlayer.Medicament();
        }
    }
}
