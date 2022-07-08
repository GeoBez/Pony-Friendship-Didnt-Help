using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Preparation : MonoBehaviour
{
    static Preparation Instance;
    Button Skip_Button;
    Text PreparationTime;
    public const int DefaultTimePreparation = 30;
    public const int DefaultCountCoin = 20;
    private int PassCountCoin;
    DateTime Timer;
    float RemainingTime;
    private void Start()
    {
        Instance = this;
        PassCountCoin = DefaultCountCoin;
        PreparationTime = GetComponentInChildren<Text>();
        Skip_Button = GetComponentInChildren<Button>();
        WaveController.EndWave += Reset;
        Reset();
    }
    private void Reset()
    {
        PlayerStatistics.AddCoins(50);
        Timer = DateTime.Now.AddSeconds(DefaultTimePreparation);
        RemainingTime = DefaultTimePreparation;
        StartCoroutine(TimerStart());
        ActiveUI(true);
    }
    private void ActiveUI(bool enable)
    {
        Skip_Button.gameObject.SetActive(enable);
        PreparationTime.gameObject.SetActive(enable);
    }
    private void StartWave()
    {
        WaveController.instance.Launch();
        ActiveUI(false);
    }
    private string FormatedTextInTimeSpan(TimeSpan newTime)
    {
        return  string.Format("Time {0}:{1}", new object[]
            {
                newTime.Minutes, newTime.Seconds,
            });
    }
    public static void ContinueTimer()
    {
        if (!Menu.GameIsPaused) return;
        Instance.Timer = DateTime.Now.AddSeconds(Instance.RemainingTime);
        Instance.StartCoroutine(Instance.TimerStart());
    }
    public static void Upgrade(IModiferUpgrade upgrade)
    {
        var mod = upgrade.Expansion(Instance.PassCountCoin);
        if (mod is int i) Instance.PassCountCoin = i;
    }
    private IEnumerator TimerStart()
    {
        TimeSpan newTime = new();
        while (!Menu.GameIsPaused)
        {
            newTime = Timer - DateTime.Now;
            RemainingTime = newTime.Minutes*60+ newTime.Seconds;
            string TimeText = FormatedTextInTimeSpan(newTime);
            PreparationTime.text = TimeText;
            if (newTime.Seconds == 0 && newTime.Minutes == 0)
                StartWave();
            yield return new WaitForSeconds(0.1F);
        }
        yield break;
    }

    public void OnButton()
    {
        StartWave();
        int Procent = (int)((float)(Timer - DateTime.Now).Seconds / DefaultTimePreparation * 100);
        Procent = (int)((float)PassCountCoin / 100 * Procent);
        PlayerStatistics.AddCoins(Procent);
    }

    public void Reset_Timer(bool isBoss)
    {
       // timer = isBoss? bossTimer: default_time;
    }
}