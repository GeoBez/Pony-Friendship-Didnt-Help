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


//все моды ниже
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

public class Mode_DoubleDenomination : Modes
{
    public Mode_DoubleDenomination()
    {
        name = "Двойной номинал";
        description = "Все выпадающие монетки стоят 2";
    }
    public override void MainModeDo()
    {
        Coin.coin_Denomination = 2;
    }
}

public class Mode_CleverLeaf : Modes
{
    public Mode_CleverLeaf()
    {
        name = "Лист клевера";
        description = "Увеличивает шанс выпадения монет на 10%";
    }
    public override void MainModeDo()
    {
        Coin.probability = 40;
    }
}

public class Mode_MoreBits : Modes
{
    public Mode_MoreBits()
    {
        name = "Больше битсов!";
        description = "+100 монеток";
    }
    public override void MainModeDo()
    {
        Coin_Count_Text.coin_Count += 100;
    }
}

public class Mode_Sturdy : Modes
{
    public Mode_Sturdy()
    {
        name = "Здоровяк";
        description = "Увеличение количества жизни на 10%";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.maxHealth += (int)(player.maxHealth * 0.1);
        player.Health += (int)(player.maxHealth * 0.1);
    }
}

public class Mode_HealthyHealth : Modes
{
    public Mode_HealthyHealth()
    {
        name = "Здорово, здоровье";
        description = "Увеличение количества жизни на 20 хп";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.maxHealth += 20;
        player.Health += 20;
    }
}

public class Mode_NewHorseshoes : Modes
{
    public Mode_NewHorseshoes()
    {
        name = "Новые подковы";
        description = "Повышение скорости передвижения на 5%";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.speed += (float)(player.speed * 0.1);
    }
}

public class Mode_OneTimeTreatment : Modes
{
    public Mode_OneTimeTreatment()
    {
        name = "Разовое лечение";
        description = "Восстанавливает здоровье до максимума";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.Health = player.maxHealth;
    }
}

public class Mode_MoreHealth : Modes
{
    public Mode_MoreHealth()
    {
        name = "";
        description = "";
    }

    public override void MainModeDo()
    {
        Tower tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();

        tree.maxHealth += 20;
        tree.health += 20;
    }
}

public class Mode_TimeIsMoney : Modes
{
    public Mode_TimeIsMoney()
    {
        name = "Время - деньги";
        description = "За пропуск волны дается в 2 раза больше монет";
    }

    public override void MainModeDo()
    {
        Coin.coinForWavePass *= 2;
    }
}

public class Mode_IAmPower : Modes
{
    public Mode_IAmPower()
    {
        name = "Я есть сила";
        description = "Повышает сила атаки в 2 раза";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.damage *= 2;
    }
}

public class Mode_PowerPlus : Modes
{
    public Mode_PowerPlus()
    {
        name = "Сила+";
        description = "Увеличение урона на 5 единиц";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.damage += 5;
    }
}


