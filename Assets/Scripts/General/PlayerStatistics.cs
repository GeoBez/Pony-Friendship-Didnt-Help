using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerStatistics
{
    public static int Experience { get; private set; }

    public static event Action Lack—oins;
    public static int Coins { get; private set; }

    private const int ExpNextLevelDefault = 20;

    public static int ExpNextLevel { get; private set; }

    public static int ExpCurLevel { get; private set; }

    public static event Action UpdateLevel;
    public static int Level { get; private set; }

    public static int Received—ards { get; private set; }

    private static int enemyDeathCount;

    private static float _startTime;
    public static void GiveOneCard()
    {
        Received—ards++;
    }
    public static string[] GetStatistic()
    {
        string[] stats = new string[3];
        stats[0] = $"¬˚ ÔÓ‰ÂÊ‡ÎËÒ¸ {Mathf.Round((Time.time - _startTime) / 60)} ÏËÌÛÚ.\nœÓÔÓ·ÛÈÚÂ ÒÌÓ‚‡";
        stats[1] = Coins.ToString();
        stats[2] = enemyDeathCount.ToString();
        return stats;
    }
    public static void ResetAll()
    {
        enemyDeathCount = 0;
        EntityEngine.SomeoneDead += (T) => { if (T == EntityEngine.TypeTeam.Enemy) enemyDeathCount++; };
        _startTime = Time.time;
        ExpNextLevel = ExpNextLevelDefault;
        ExpCurLevel = Level = Coins = Experience = 0;
        Lack—oins = UpdateLevel = null;
    }
    public static void BuyPurchase(IPurchased purchased)
    {
        if (Coins < purchased.PriÒe)
        {
            Lack—oins?.Invoke();
            return;
        }
        Coins -= purchased.PriÒe;
        UnityEngine.Object.Instantiate((Tower)purchased, Player.MainPlayer.transform.position, Quaternion.identity);
        Coin_Count_Text.UpdateCountCoin();
    }

    public static void AddCoins(int count = 1)
    {
        if (count > 0)
        Coins += count;
        Coin_Count_Text.UpdateCountCoin();
    }
    public static void AddExperience(int count = 1)
    {
        if (count < 0) return;
        Experience += count;
        if(ExpNextLevel < Experience)
        {
            ExpCurLevel = ExpNextLevel;
            ExpNextLevel += Mathf.RoundToInt(ExpNextLevel * 0.5F);
            Level++;
            UpdateLevel?.Invoke();
        }
        Exp_Bar.instance.Update_Bar();
    }
}

