using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Card
{
    public Card(string _name, string _description)
    {
        name = _name;
        description = _description;
    }
    public string name;
    public string description;
}
