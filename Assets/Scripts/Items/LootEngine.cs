using System;
using UnityEngine;

public class LootEngine : MonoBehaviour
{
    public ILoot Loot { get; private set; }
    public bool isStatic = false;
    public Rigidbody2D Rigidbody { get; private set; }

    public static void AddLoot(ILoot _loot, Vector3 vector)
    {
        if (_loot == null) { 
            Debug.LogWarning("Object reference not set to an instance of an object");
            return;
        }

        ILoot loot = (ILoot)_loot.Clone();
        GameObject go = Instantiate(Resources.Load<GameObject>($"Prefabs\\Loot\\{loot.Name}"),
            vector, Quaternion.identity);
        LootEngine Engine = go.GetComponent<LootEngine>();
        loot.LootEngine = Engine;
        Engine.Loot = loot;
        Engine.Rigidbody = go.GetComponent<Rigidbody2D>();
        ((Loot)Engine.Loot).Start();
    }
}