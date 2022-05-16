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
        name = "������";
        description = "����������� ������ ����� �����";
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
        name = "������� �������";
        description = "��� ���������� ������� ����� 2";
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
        name = "���� �������";
        description = "����������� ���� ��������� ����� �� 10%";
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
        name = "������ ������!";
        description = "+100 �������";
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
        name = "��������";
        description = "���������� ���������� ����� �� 10%";
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
        name = "�������, ��������";
        description = "���������� ���������� ����� �� 20 ��";
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
        name = "����� �������";
        description = "��������� �������� ������������ �� 5%";
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
        name = "������� �������";
        description = "��������������� �������� �� ���������";
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
        name = "����� - ������";
        description = "�� ������� ����� ������ � 2 ���� ������ �����";
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
        name = "� ���� ����";
        description = "�������� ���� ����� � 2 ����";
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
        name = "����+";
        description = "���������� ����� �� 5 ������";
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
        name = "������� ������� ���";
        description = "������ ��� ����� �� �������";
    }

    public override void MainModeDo()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isMeleeAttacker = false;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Change_Attack>().ChangeAttack();  
    }
}


public class Mode_SittingUpper : Modes //�� ��������
{
    public Mode_SittingUpper()
    {
        name = "���� ������ - ������� ������";
        description = "����������� ������ �����";
    }

    public override void MainModeDo()
    {
        //throw new System.Exception("You tried to use unworking Mode_SittingUpper");

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Weapon>().detectionDistance = 10;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMeleeAttacks>().attackRange = 5;
    }
}


