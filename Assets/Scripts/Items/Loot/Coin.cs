using UnityEngine;
public class Coin : Loot, ILoot
{
    private readonly int _Value;
    public int Value => _Value;
           
    public Coin(int _value = 1)
    {
        if (_value > 0)
            _Value = _value;
        else
            _Value = 1;
    }

    public string Name => nameof(Coin);
    public override void Action()
    {
        //PlayerStatistics.AddCoins(_Value);
        base.Action();
    }
}