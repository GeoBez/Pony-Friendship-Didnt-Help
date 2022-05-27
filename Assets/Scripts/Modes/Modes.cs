using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface ModeActivate{
    void Activate();
    void MainModeDo();
    string GetName();
    string GetDescription();
}
public abstract class Modes : ModeActivate//: MonoBehaviour//, ModeActivate
{
    public string modeName;
    public string modeDescription;
    public Image Image;
    //ссылка на карточку

    public bool isBlocked = false; //пригодится для ограничений
    public bool isActive = false;
    public bool isUsed = false;
    protected Player player;
    public virtual void Activate()
    {
        isActive = true;
        isBlocked = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        MainModeDo();
    }

    public virtual void MainModeDo() {}
    public string GetName() => modeName;
    public string GetDescription() => modeDescription;
    public Image GetImage() => Image;
}





