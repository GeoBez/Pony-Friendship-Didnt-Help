using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class AttackOfTowers : CardUpgrade
    {
        public override Card Card => new Card("Большое по зубам", "Большие враги становятся уязвимыми");

        protected override void Function()
        {
            Player.MainPlayer.PlayerMelee.EnemyAttached.Add(Enemy.TypeEnemy.Tower);
        }
    }
}
