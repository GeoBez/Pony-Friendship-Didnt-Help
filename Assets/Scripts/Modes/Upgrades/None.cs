using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Upgrades
{
    public class None : CardUpgrade
    {
        public override Card Card => new Card("Пусто", "Улучшений больше нет");

        protected override void Function()
        {
            Debug.Log("Activate Card: None");
        }
    }
}
