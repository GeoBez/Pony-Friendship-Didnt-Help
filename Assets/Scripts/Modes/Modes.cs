using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ModeActivate{
    void Activate();
    void MainModeDo();
    string GetName();
    string GetDescription();
}
public abstract class Modes : ModeActivate//MonoBehaviour, ModeActivate
{
    public static string name;
    public static string description;
    //ссылка на карточку

    public static  bool isBlocked = false; //пригодится для ограничений
    public static bool isActive = false;
    public virtual void Activate()
    {
        isActive = true;
        isBlocked = true;

        MainModeDo();
    }

    public virtual void MainModeDo() {}
    public string GetName() => name;
    public string GetDescription() => description;
}

public class Mode_Magnit : Modes
{
    public Mode_Magnit()
    {
        name = "Магнит";
        description = "Увеличивает радиус сбора монет";
        //Activate();
    }

    public override void MainModeDo()
    {
        Coin.range = 12;        
    }
}


