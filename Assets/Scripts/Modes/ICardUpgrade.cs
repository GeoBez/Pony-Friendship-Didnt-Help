using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface ICardUpgrade
{
    TypeUpgrade TypeUpgrade { get; set; }
    Card Card { get; }
    void Function();

}
