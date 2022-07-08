using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////��� ���� ����
//public class Mode_Magnit : Modes
//{
//    public void Start()
//    {
//        modeName = "������";
//        modeDescription = "����������� ������ ����� �����";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager")
//            .GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Coin.range = 12;
//    }
//}

//public class Mode_DoubleDenomination : Modes
//{
//    public void Start()
//    {
//        modeName = "������� �������";
//        modeDescription = "��� ���������� ������� ����� 2";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }
//    public override void MainModeDo()
//    {
//        Coin.coin_Denomination = 2;
//    }
//}

//public class Mode_CleverLeaf : Modes
//{
//    public void Start()
//    {
//        modeName = "���� �������";
//        modeDescription = "����������� ���� ��������� ����� �� 10%";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }
//    public override void MainModeDo()
//    {
//        Coin.probability = 40;
//    }
//}

//public class Mode_MoreBits : Modes
//{
//    public void Start()
//    {
//        modeName = "������ ������!";
//        modeDescription = "+100 �������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName("������ ������".ToLower());
//    }
//    public override void MainModeDo()
//    {
//        Coin_Count_Text.coin_Count += 100;
//    }
//}

//public class Mode_Sturdy : Modes
//{
//    public void Start()
//    {
//        modeName = "��������";
//        modeDescription = "���������� ���������� ����� �� 10%";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player.MainPlayer.AddHealsMax(player.maxHealth * 0.1F);
//    }
//}

//public class Mode_HealthyHealth : Modes
//{
//    public void Start()
//    {
//        modeName = "�������, ��������";
//        modeDescription = "���������� ���������� ����� �� 20 ��";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName("������� ��������".ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player.MainPlayer.AddHealsMax(20F);
//    }
//}

//public class Mode_NewHorseshoes : Modes
//{
//    public void Start()
//    {
//        modeName = "����� �������";
//        modeDescription = "��������� �������� ������������ �� 20%";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player player = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Player>();
//        player.Speed += (float)(player.Speed * 0.2);
//    }
//}

//public class Mode_OneTimeTreatment : Modes
//{
//    public void Start()
//    {
//        modeName = "������� �������";
//        modeDescription = "��������������� �������� �� ���������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player.MainPlayer.Medicament(Player.MainPlayer.maxHealth);
//    }
//}

//public class Mode_MoreHealth : Modes ///here
//{
//    public void Start()
//    {
//        modeName = "������ ��������";
//        modeDescription = "�������� ������ ������������� �� 20 ������";
//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Tower tree = GameObject.FindGameObjectWithTag("Main Tower").GetComponent<Tower>();
//        tree.AddHealsMax(20);
//    }
//}

//public class Mode_TimeIsMoney : Modes //here
//{
//    public void Start()
//    {
//        modeName = "����� - ������";
//        modeDescription = "�� ������� ����� ������ � 2 ���� ������ �����";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Coin.coinForWavePass *= 2;
//        //player.mode_TimeIsMoney = true;
//    }
//}

//public class Mode_IAmPower : Modes
//{
//    public void Start()
//    {
//        modeName = "� ���� ����";
//        modeDescription = "�������� ���� ����� � 2 ����";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player.MainPlayer.AddDamage(Player.MainPlayer.Damage);
//    }
//}

//public class Mode_PowerPlus : Modes //here
//{
//    public void Start()
//    {
//        modeName = "����+";
//        modeDescription = "���������� ����� �� 5 ������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        Player.MainPlayer.AddDamage(5F);
//    }
//}

//public class Mode_SimpleDistanteBattle : Modes //here
//{
//    public void Start()
//    {
//        modeName = "������� ������� ���";
//        modeDescription = "������ ��� ����� �� �������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        var player = Player.MainPlayer;
//        player.GetComponentInChildren<PlayerMeleeAttacks>().enabled = false;
//        player.GetComponentInChildren<Weapon>().enabled = true;
//    }
//}

//public class Mode_SittingUpper : Modes 
//{
//    public void Start()
//    {
//        modeName = "���� ������ - ������� ������";
//        modeDescription = "����������� ������ �����";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        //throw new System.Exception("You tried to use unworking Mode_SittingUpper");

//        Player.MainPlayer.GetComponentInChildren<Weapon>().detectionDistance = 10;
//        Player.MainPlayer.GetComponentInChildren<PlayerMeleeAttacks>().attackRange = 8;
//        //player.mode = true;
//    }
//}

//public class Mode_IAmSpeed : Modes
//{
//    public void Start()
//    {
//        modeName = "� ���� ��������";
//        modeDescription = "�������� ������� ����� � 1.5 ����";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        //throw new System.Exception("Bugs fouded. Every time mod used coolDown firball low");

//        var player = Player.MainPlayer;
//        var obj = player.GetComponentInChildren<PlayerMeleeAttacks>();
//        obj.SetCoolDown(obj.attackCoolDown / 2);

//        player.GetComponentInChildren<Weapon>().projectile.coolDown /= 2;
//    }
//}

//public class Mode_YouShallNoPass : Modes
//{
//    public void Start()
//    {
//        modeName = "�� �� ��������";
//        modeDescription = "�� ������ �������� �� ������ ������ � ������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName(modeName.ToLower());
//    }

//    public override void MainModeDo()
//    {
//        //player.mode_YouShallNotPass = true;

//        var _player = GameObject.FindGameObjectWithTag("MainPlayer");

//        _player.GetComponentInChildren<Weapon>().whatIsAttack = LayerMask.GetMask("Tower Enemy", "Enemy");
//        _player.GetComponentInChildren<PlayerMeleeAttacks>().enemyLayer = LayerMask.GetMask("Tower Enemy", "Enemy");
//    }
//}

//public class Mode_Extra : Modes//��� ������ ����������, ��� ���������
//{
//    public void Start()
//    {
//        modeName = "������:D";
//        modeDescription = "��� ��������� ���������� ��������";

//        var manager = GameObject.FindGameObjectWithTag("UprgadeSpritesManager").GetComponent<UpgradeCardPlayer>();
//        Image = manager.GetSpriteByName("��������� - ������");
//    }

//    public override void MainModeDo()
//    {
//        Coin_Count_Text.coin_Count += 50;
//    }
//}






