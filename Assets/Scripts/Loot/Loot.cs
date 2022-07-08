using UnityEngine;
using System;

public abstract class Loot
{
    public virtual void Start()
    { }
    public GameObject gameObject => LootEngine.gameObject;
    public LootEngine LootEngine { get; set; }
    public virtual void Action()
    {
        UnityEngine.Object.Destroy(gameObject);

        SoundMeneger.Play(SoundMeneger.Sounds.Loot);
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
