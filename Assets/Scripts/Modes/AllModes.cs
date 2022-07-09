using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllModes:MonoBehaviour
{
    
}

//��� ���� ����
public class Mode_Magnit : Modes
{
    public void Start()
    {
        modeName = "������";
        modeDescription = "����������� ������ ����� �����";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager")
            .GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Coin.range = 12;
        //player.mode_Magnit = true;
    }
}

public class Mode_DoubleDenomination : Modes
{
    public void Start()
    {
        modeName = "���������� �������";
        modeDescription = "��� ���������� ������� ����� 4";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }
    public override void MainModeDo()
    {
        Coin.coin_Denomination = 4;
        //player.mode_Double_Denomination = true;
    }
}

public class Mode_CleverLeaf : Modes
{
    public void Start()
    {
        modeName = "���� �������";
        modeDescription = "���� ��������� ����� ������ �� 20%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }
    public override void MainModeDo()
    {
        Coin.probability += 20;
        //player.mode_Clover_Leaf = true;
    }
}

public class Mode_MoreBits : Modes
{
    public void Start()
    {
        modeName = "������ ������!";
        modeDescription = "+100 �������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName("������ ������".ToLower());
    }
    public override void MainModeDo()
    {
        Coin_Count_Text.coin_Count += 100;
        //player.mode_MoreBits = true;
    }
}

public class Mode_Sturdy : Modes
{
    public void Start()
    {
        modeName = "��������";
        modeDescription = "���������� ���������� ����� �� 10%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();

        player.maxHealth += (int)(player.maxHealth * 0.1);
        player.Health += (int)(player.maxHealth * 0.1);
        //player.mode_Sturdy = true; ������!
    }
}

public class Mode_HealthyHealth : Modes
{
    public void Start()
    {
        modeName = "�������, ��������";
        modeDescription = "���������� ���������� ����� �� 20 ��";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName("������� ��������".ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();

        player.maxHealth += 20;
        player.Health += 20;

        //player.mode_HealthyHealth = true; ���� ������!
    }
}

public class Mode_NewHorseshoes : Modes
{
    public void Start()
    {
        modeName = "����� �������";
        modeDescription = "��������� �������� ������������ �� 20%";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();

        player.Speed += (float)(player.Speed * 0.2);
        //player.mode_NewHorseshoes = true; ���� ������, �� ��������� ��������!
    }
}

public class Mode_OneTimeTreatment : Modes
{
    public void Start()
    {
        modeName = "������� �������";
        modeDescription = "��������������� �������� �� ���������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();
        player.Health = player.maxHealth;

        //player.mode_OneTimeTreatment = true; ������ ����!
    }
}

public class Mode_MoreHealth : Modes ///here
{
    public void Start()
    {
        modeName = "������ ��������";
        modeDescription = "�������� ������ ������������� �� 20 ������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Tower tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();

        tree.maxHealth += 20;
        tree.health += 20;
        //player.mode_MoreHealth = true;
    }
}

public class Mode_TimeIsMoney : Modes //here
{
    public void Start()
    {
        modeName = "����� - ������";
        modeDescription = "������ ����� �� ������� �����";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Coin.coinForWavePass *= 2;
        //player.mode_TimeIsMoney = true;
    }
}

public class Mode_IAmPower : Modes
{
    public void Start()
    {
        modeName = "� ���� ����";
        modeDescription = "�������� ���� ����� � 2 ����";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();
        player.Damage *= 2;
        //player.mode_IAmPower = true;
    }
}

public class Mode_PowerPlus : Modes //here
{
    public void Start()
    {
        modeName = "����+";
        modeDescription = "���������� ����� �� 5 ������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();
        player.Damage += 5;
        //player.mode_PowerPlus = true;
    }
}

public class Mode_SimpleDistanteBattle : Modes //here
{
    public void Start()
    {
        modeName = "������� ������� ���";
        modeDescription = "������ ��� ����� �� �������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        var player = GameObject.FindGameObjectWithTag("MainPlayer");
        player.GetComponentInChildren<PlayerMeleeAttacks>().enabled = false;
        player.GetComponentInChildren<Weapon>().enabled = true;

        //GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isMeleeAttacker = false;
        //GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Change_Attack>().ChangeAttack();  
    }
}

public class Mode_SittingUpper : Modes 
{
    public void Start()
    {
        modeName = "���� ������ - ������� ������";
        modeDescription = "����������� ������ �����";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("You tried to use unworking Mode_SittingUpper");

        GameObject.FindGameObjectWithTag("MainPlayer").GetComponentInChildren<Weapon>().detectionDistance = 10;
        GameObject.FindGameObjectWithTag("MainPlayer").GetComponentInChildren<PlayerMeleeAttacks>().attackRange = 8;
        //player.mode = true;
    }
}

public class Mode_IAmSpeed : Modes
{
    public void Start()
    {
        modeName = "� ���� ��������";
        modeDescription = "�������� ������� ����� � 1.5 ����";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("Bugs fouded. Every time mod used coolDown firball low");

        var player = GameObject.FindGameObjectWithTag("MainPlayer");
        var obj = player.GetComponentInChildren<PlayerMeleeAttacks>();
        obj.SetCoolDown(obj.attackCoolDown / 2);

        player.GetComponentInChildren<Weapon>().projectile.coolDown /= 2;
    }
}

public class Mode_YouShallNoPass : Modes
{
    public void Start()
    {
        modeName = "�� �� ��������";
        modeDescription = "�� ������ �������� �� ������� �������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName(modeName.ToLower());
    }

    public override void MainModeDo()
    {
        //player.mode_YouShallNotPass = true;

        var _player = GameObject.FindGameObjectWithTag("MainPlayer");

        _player.GetComponentInChildren<Weapon>().whatIsAttack = LayerMask.GetMask("Tower Enemy", "Enemy");
        _player.GetComponentInChildren<PlayerMeleeAttacks>().enemyLayer = LayerMask.GetMask("Tower Enemy", "Enemy");
    }
}

public class Mode_Extra : Modes//��� ������ ����������, ��� ���������
{
    public void Start()
    {
        modeName = "������:D";
        modeDescription = "��� ��������� ���������� ��������";

        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UprgadeSpritesManager>();
        Image = manager.GetSpriteByName("��������� - ������");
    }

    public override void MainModeDo()
    {
        Coin_Count_Text.coin_Count += 50;
    }
}






