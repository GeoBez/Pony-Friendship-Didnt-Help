
public class Heal : Loot, ILoot
{
    public string Name => nameof(Heal);
    public override void Action()
    {
        Player.MainPlayer.Medicament();
        base.Action();
    }
}
