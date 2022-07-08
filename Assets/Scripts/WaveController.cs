using System.Collections;
using System.Collections.Generic;
using System;
using URandom = UnityEngine.Random;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Waves[] Waves;
    public static int Wave_Number;
    public static int NeedToKill { get; private set; }
    public static int CountToKill { get; private set; }
    /// <summary>
    /// ������� ������ ��������� Preparation
    /// �� ������ ����� ���������� �� �������
    ///</summary>
    public static event Action Preporation;
    /// <summary>
    /// ������� ����� ����� ��������� End
    /// �� ������ ����� ���������� �� �������
    ///</summary>
    public static event Action EndWave;
    /// <summary>
    /// �� ������ ����� ���������� �� �������
    ///</summary>
    public static event Action StartWave;
    /// <summary>
    /// �� ������ ����� ���������� �� �������
    ///</summary>
    public static event Action EndWar;
    public static WaveController instance { get; private set; }

    public StateWave stateWave { get; private set; }

    public enum StateWave
    {
        Preparation,
        Start,
        End,
        WarEnd
    }
    private void Start()
    {
        instance = this;
        Wave_Number = 0;
        EntityEngine.SomeoneDead += DeadEnemy;
    }
    private void ChangeState(StateWave state)
    {
        stateWave = state;
        Debug.LogWarning($"Change State: {state}");
        switch (state)
        {
            case StateWave.Preparation:
                Wave_Number++;
                Preporation?.Invoke();
                break;
            case StateWave.Start:
                Rise_Wave();
                StartWave?.Invoke();
                break;
            case StateWave.End:
                EndWave?.Invoke();
                ChangeState(StateWave.Preparation);
                break;
            case StateWave.WarEnd:
                EndWar?.Invoke();
                break;
        }
    }
    private void DeadEnemy(EntityEngine.TypeTeam type)
    {
        if (type != EntityEngine.TypeTeam.Enemy) return;
        if (Enemy.Enemys.Count <= 0)
            ChangeState(Waves.Length - 1 > 0? StateWave.End : StateWave.WarEnd);
    }
    public void Launch()
    {
        if (stateWave == StateWave.Preparation)
            ChangeState(StateWave.Start);
        else
            Debug.Log($"����� �������� ����� ������ �� ��������� {StateWave.Preparation}, � ������ {stateWave}") ;
    }
    private void Rise_Wave()
    {
        NeedToKill = 0;
        for (int i = 0; i < Waves[Wave_Number].waves.Length; i++)
        {
            var portal = Waves[Wave_Number].waves[i].Portal;
            var enemy = Waves[Wave_Number].waves[i].Enemy;
            var enemyCount = Waves[Wave_Number].waves[i].GetEnemyCount();

            NeedToKill += enemyCount;
            

            portal.GetComponent<Enemy_Spawn>().SpawnEnemy(enemy, enemyCount);

        }
        CountToKill = NeedToKill;
        Debug.Log($"Spawn enemy count: {CountToKill}");
    }   
        
}



[Serializable]
public class Waves
{
    public WaveSettings[] waves;
    public bool IsBoss = false;
}
[Serializable]
public class WaveSettings
{
    public GameObject Enemy;
    [SerializeField] private int _min_Count_Enemy;
    [SerializeField] private int _max_Count_Enemy;
    public GameObject Portal;

    public int GetEnemyCount()
    {
        return URandom.Range(_min_Count_Enemy, _max_Count_Enemy+1);
    }
}

