using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class Luck : CardUpgrade, IModiferUpgrade
    {
        public override Card Card => new Card("Удача!", "Шанс выпадения монет увеличивается в 3 раза");

        public Func<object, object> Expansion => (obj) =>
        {
            if (!(obj is ILoot[] loots)) 
                return obj;

            ILoot[] newloots = new ILoot[loots.Length + 2];
            Coin coin = new Coin();
            for(int i =0;i< newloots.Length; i++)
            {
                if (i >= loots.Count())
                {
                    newloots[i] = (Coin)coin.Clone();
                    continue;
                }
                if(loots[i] is Coin coin1 && coin1.Value> coin.Value)
                    coin = (Coin)coin1.Clone();
            }
            return newloots;
        };

        protected override void Function()
        {
            Enemy.UpgradeLoot(this);
        }
    }
}
