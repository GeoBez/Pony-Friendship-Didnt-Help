using UnityEngine;
public class Coin : Loot, ILoot
{
    private readonly int _Value;
    public int Value => _Value;
           
    public Coin()
    {
        _Value = Player.MainPlayer.coinDenomination;
    }

    public Coin(int _value =1)
    {
        if (_value > 0)
            _Value = _value;
        else
            _Value = 1;
    }

    public string Name => nameof(Coin);
    public override void Action()
    {
        PlayerStatistic.AddCoins(_Value);
        base.Action();
    }
}