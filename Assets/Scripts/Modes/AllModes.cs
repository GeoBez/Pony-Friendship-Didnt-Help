using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllModes:MonoBehaviour
{
    
}

//все моды ниже
public class Mode_Magnit : Modes
{
    public Mode_Magnit()
    {
        modeName = "Магнит";
        modeDescription = "Увеличивает радиус сбора монет";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Coin.range = 12;
        //player.mode_Magnit = true;
    }
}

public class Mode_DoubleDenomination : Modes
{
    public Mode_DoubleDenomination()
    {
        modeName = "Двойной номинал";
        modeDescription = "Все выпадающие монетки стоят 2";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }
    public override void MainModeDo()
    {
        Coin.coin_Denomination = 2;
        //player.mode_Double_Denomination = true;
    }
}

public class Mode_CleverLeaf : Modes
{
    public Mode_CleverLeaf()
    {
        modeName = "Лист клевера";
        modeDescription = "Увеличивает шанс выпадения монет на 10%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }
    public override void MainModeDo()
    {
        Coin.probability = 40;
        //player.mode_Clover_Leaf = true;
    }
}

public class Mode_MoreBits : Modes
{
    public Mode_MoreBits()
    {
        modeName = "Больше битсов!";
        modeDescription = "+100 монеток";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }
    public override void MainModeDo()
    {
        Coin_Count_Text.coin_Count += 100;
        //player.mode_MoreBits = true;
    }
}

public class Mode_Sturdy : Modes
{
    public Mode_Sturdy()
    {
        modeName = "Здоровяк(!)";
        modeDescription = "Увеличение количества жизни на 10%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.maxHealth += (int)(player.maxHealth * 0.1);
        player.Health += (int)(player.maxHealth * 0.1);
        //player.mode_Sturdy = true; ошибка!
    }
}

public class Mode_HealthyHealth : Modes
{
    public Mode_HealthyHealth()
    {
        modeName = "Здорово, здоровье (!)";
        modeDescription = "Увеличение количества жизни на 20 хп";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.maxHealth += 20;
        player.Health += 20;

        //player.mode_HealthyHealth = true; Есть ошибка!
    }
}

public class Mode_NewHorseshoes : Modes
{
    public Mode_NewHorseshoes()
    {
        modeName = "Новые подковы (!)";
        modeDescription = "Повышение скорости передвижения на 20%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.Speed += (float)(player.Speed * 0.2);
        //player.mode_NewHorseshoes = true; есть ошибка, не закрывает карточку!
    }
}

public class Mode_OneTimeTreatment : Modes
{
    public Mode_OneTimeTreatment()
    {
        modeName = "Разовое лечение (!)";
        modeDescription = "Восстанавливает здоровье до максимума";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.Health = player.maxHealth;

        //player.mode_OneTimeTreatment = true; ошибка есть!
    }
}

public class Mode_MoreHealth : Modes
{
    public Mode_MoreHealth()
    {
        modeName = "Больше здоровья";
        modeDescription = "Здоровье дерева увеличивается на 20 единиц";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Tower tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();

        tree.maxHealth += 20;
        tree.health += 20;
        //player.mode_MoreHealth = true;
    }
}

public class Mode_TimeIsMoney : Modes
{
    public Mode_TimeIsMoney()
    {
        modeName = "Время - деньги";
        modeDescription = "За пропуск волны дается в 2 раза больше монет";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Coin.coinForWavePass *= 2;
        //player.mode_TimeIsMoney = true;
    }
}

public class Mode_IAmPower : Modes
{
    public Mode_IAmPower()
    {
        modeName = "Я есть сила";
        modeDescription = "Повышает сила атаки в 2 раза";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.damage *= 2;
        //player.mode_IAmPower = true;
    }
}

public class Mode_PowerPlus : Modes
{
    public Mode_PowerPlus()
    {
        modeName = "Сила+";
        modeDescription = "Увеличение урона на 5 единиц";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.damage += 5;
        //player.mode_PowerPlus = true;
    }
}

public class Mode_SimpleDistanteBattle : Modes
{
    public Mode_SimpleDistanteBattle()
    {
        modeName = "Простой дальний бой";
        modeDescription = "Меняет тип атаки на дальний";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isMeleeAttacker = false;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Change_Attack>().ChangeAttack();  
    }
}

public class Mode_SittingUpper : Modes 
{
    public Mode_SittingUpper()
    {
        modeName = "Сижу высоко - стреляю далеко";
        modeDescription = "Увеличивает радиус атаки";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("You tried to use unworking Mode_SittingUpper");

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().detectionDistance = 10;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMeleeAttacks>().attackRange = 5;
        //player.mode = true;
    }
}

public class Mode_IAmSpeed : Modes
{
    public Mode_IAmSpeed()
    {
        modeName = "Я есть скорость";
        modeDescription = "Повышает частоту атаки в 1.5 раза";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("Bugs fouded. Every time mod used coolDown firball low");

        var player = GameObject.FindGameObjectWithTag("Player");
        var obj = player.GetComponentInChildren<PlayerMeleeAttacks>();
        obj.SetCoolDown(obj.attackCoolDown / 2);

        player.GetComponentInChildren<Weapon>().projectile.coolDown /= 2;
    }
}

public class Mode_YouShallNoPass : Modes
{
    public Mode_YouShallNoPass()
    {
        modeName = "Ты не пройдешь";
        modeDescription = "Вы можете стрелять по врагам идущим к дереву";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        player.mode_YouShallNotPass = true;

        var _player = GameObject.FindGameObjectWithTag("Player");

        _player.GetComponentInChildren<Weapon>().whatIsAttack = LayerMask.GetMask("Tower Enemy", "Enemy");
        _player.GetComponentInChildren<PlayerMeleeAttacks>().enemyLayer = LayerMask.GetMask("Tower Enemy", "Enemy");
    }
}

public class Mode_Extra : Modes//Это скорее исключение, чем улучшение
{
    public Mode_Extra()
    {
        modeName = "Уууупс:D";
        modeDescription = "Это улучшение невозможно получить";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image.sprite = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Coin_Count_Text.coin_Count += 50;
    }
}






