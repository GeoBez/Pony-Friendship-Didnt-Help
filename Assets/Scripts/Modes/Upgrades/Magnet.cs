﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upgrades
{
    public class Magnet : CardUpgrade
    {
        public override Card Card => new Card("Магнит", "Увеличивает радиус сбора монет");

        protected override void Function()
        {
            Player.MainPlayer.MagtetUpdate();
        }
    }
}