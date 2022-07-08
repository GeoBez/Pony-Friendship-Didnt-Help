using System.Collections.Generic;

public interface IPurchased
{
    public int Priñe { get; }
    public string Name { get; }
    public string Description { get; }
    public List<string> Specifications { get; }

}