using System;

namespace Upgrades
{
    public class DoubleCoin : CardUpgrade, IModiferUpgrade
    {
        public Func<object, object> Expansion => ExpansionDouble;

        private object ExpansionDouble(object obj)
        {
            if (!(obj is ILoot[] loots))
                return obj;

            for (int i = 0; i < loots.Length; i++)
            {
                if (loots[i] is Coin coin)
                {
                    loots[i] = new Coin(coin.Value * 2);
                }
            }
            return loots;
        }
        public override Card Card => new Card("Двойной номинал", "Выпадающие монеты X2");

        protected override void Function()
        {
            Enemy.UpgradeLoot(this);
        }
    }
}
