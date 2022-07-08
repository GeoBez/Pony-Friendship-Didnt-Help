
public class Experience : Loot,  ILoot
    {
    private readonly int Value;
    public Experience(int _Value = 1)
    {
        if(_Value>0)
        Value = _Value;
        else
            Value = 1;
    }
    public string Name => nameof(Experience);

    public override void Action()
    {
        PlayerStatistics.AddExperience(Value);
        base.Action();
    }
}
