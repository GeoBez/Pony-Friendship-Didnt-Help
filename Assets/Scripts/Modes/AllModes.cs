using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllModes : MonoBehaviour
{

}

//��� ���� ����
public class Mode_Magnit : Modes
{
    public Mode_Magnit()
    {
        modeName = "������";
        modeDescription = "����������� ������ ����� �����";
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
        modeName = "������� �������";
        modeDescription = "��� ���������� ������� ����� 2";
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
        modeName = "���� �������";
        modeDescription = "����������� ���� ��������� ����� �� 10%";
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
        modeName = "������ ������!";
        modeDescription = "+100 �������";
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
        modeName = "��������";
        modeDescription = "���������� ���������� ����� �� 10%";
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
        modeName = "�������, ��������";
        modeDescription = "���������� ���������� ����� �� 20 ��";
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
        modeName = "����� �������";
        modeDescription = "��������� �������� ������������ �� 5%";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        player.Speed += (float)(player.Speed * 0.1);
    }
}

public class Mode_OneTimeTreatment : Modes
{
    public Mode_OneTimeTreatment()
    {
        modeName = "������� �������";
        modeDescription = "��������������� �������� �� ���������";
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
        modeName = "������ ��������";
        modeDescription = "�������� ������ ������������� �� 20 ������";
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
        modeName = "����� - ������";
        modeDescription = "�� ������� ����� ������ � 2 ���� ������ �����";
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
        modeName = "� ���� ����";
        modeDescription = "�������� ���� ����� � 2 ����";
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
        modeName = "����+";
        modeDescription = "���������� ����� �� 5 ������";
    }

    public override void MainModeDo()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.damage += 5;
    }
}

public class Mode_SimpleDistanteBattle : Modes
{
    public Mode_SimpleDistanteBattle()
    {
        modeName = "������� ������� ���";
        modeDescription = "������ ��� ����� �� �������";
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
        modeName = "���� ������ - ������� ������";
        modeDescription = "����������� ������ �����";
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("You tried to use unworking Mode_SittingUpper");

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().detectionDistance = 10;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMeleeAttacks>().attackRange = 5;
    }
}

public class Mode_IAmSpeed : Modes
{
    public Mode_IAmSpeed()
    {
        modeName = "� ���� ��������";
        modeDescription = "�������� ������� ����� � 1.5 ����";
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
        modeName = "�� �� ��������";
        modeDescription = "�� ������ �������� �� ������ ������ � ������";
    }

    public override void MainModeDo()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponentInChildren<Weapon>().whatIsAttack = LayerMask.GetMask("Tower Enemy", "Enemy");
        player.GetComponentInChildren<PlayerMeleeAttacks>().enemyLayer = LayerMask.GetMask("Tower Enemy", "Enemy");
    }
}




