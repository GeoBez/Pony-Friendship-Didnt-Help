using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class CardUpgrade : ICardUpgrade
{
    public abstract Card Card { get; }
    public TypeUpgrade TypeUpgrade { get; set; }
    protected abstract void Function();
    void ICardUpgrade.Function()
    {
        Function();
        //SoundMeneger.Play(SoundMeneger.Sounds.UseUpgrade);
    }
}
