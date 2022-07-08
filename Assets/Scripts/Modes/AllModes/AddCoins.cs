using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AddCoins : CardUpgrade
    {
        public override Card Card => new Card("Финансист!", "+100 монеток");

        protected override void Function()
        {
            PlayerStatistic.AddCoins(100);
        }
    }
}
