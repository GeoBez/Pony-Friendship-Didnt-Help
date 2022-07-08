using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class TowerHealth : CardUpgrade
    {
        public override Card Card => new Card("Дерево жизни", "Увеличивает здоровье дерева на 20%");

        protected override void Function()
        {
            Tower.Instance.AddHealsMax(Tower.Instance.maxHealth*0.2F);
        }
    }
}
