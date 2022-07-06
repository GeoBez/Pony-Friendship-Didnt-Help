using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatistic
{
    public static int Experience { get; private set; }

    public static int Coins { get; private set; }

    public static int ExpNextLevel { get; private set; }

    public static int ExpCurLevel { get; private set; }

    public static int Level { get; private set; }

    public static int Received—ards { get; private set; }

    //public static event Action Lack—oins;
    public static event Action UpdateLevel;
    
    private static int enemyDeathCount;
    private static float _startTime;
    
    private const int ExpNextLevelDefault = 10;

    public static void AddExperience(int count = 1)
    {
        if (count < 0)
            return;
        Experience += count;

        if (ExpNextLevel < Experience)
        {
            ExpCurLevel = ExpNextLevel;
            ExpNextLevel += (int)(ExpNextLevel*0.5f);
            Level++;
            UpdateLevel?.Invoke();
        }

        Exp_Bar.instance.Update_Bar();
    }

    public static void ResetAll()
    {
        enemyDeathCount = 0;
        //EntityEngine.SomeoneDead += (T) => { if (T == EntityEngine.TypeTeam.Enemy) enemyDeathCount++; };
        _startTime = Time.time;
        ExpNextLevel = ExpNextLevelDefault;
        ExpCurLevel = Level = Coins = Experience = 0;
        //Lack—oins = UpdateLevel = null;
    }
}
