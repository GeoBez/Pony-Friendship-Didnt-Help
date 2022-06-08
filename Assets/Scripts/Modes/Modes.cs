using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public interface ModeActivate{
    void Activate();
    void MainModeDo();
    string GetName();
    string GetDescription();
    Sprite GetImage();
}
public abstract class Modes : MonoBehaviour, ModeActivate
{
    public string modeName;
    public string modeDescription;
    public Sprite Image;
    //������ �� ��������

    public bool isBlocked = false; //���������� ��� �����������
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
    public Sprite GetImage() => Image;
}





