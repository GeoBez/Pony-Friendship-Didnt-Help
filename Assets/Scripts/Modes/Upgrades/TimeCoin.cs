using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class TimeCoin : CardUpgrade, IModiferUpgrade
    {
        public override Card Card => new Card("Время - деньги", "За пропуск волны дается в 2 раза больше монет");

        public Func<object, object> Expansion => (i) => { if(i is int num) return num * 2; return null; };

        protected override void Function()
        {
            Preparation.Upgrade(this);
        }
    }
}
