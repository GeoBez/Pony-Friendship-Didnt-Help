using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Waves[] Waves;

    public static int Wave_Number;
    public static int NeedToKill;

    private bool _isWorking;
    private bool isWavesEnd = false;


    private Preparation_Script preparation;

    private void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        Wave_Number = 0;

        //LaunchWave();
    }

    private void FixedUpdate()
    {
        //Debug.Log(isNotWavesEnd);
        Debug.Log(Wave_Number + " Need to kill " +NeedToKill);
        if (!isWavesEnd)
        {
            if (NeedToKill == 0 && _isWorking)
            {
                if ((Waves.Length >= Wave_Number + 1) && (Waves[Wave_Number + 1].IsBoss))
                    preparation.GetComponent<Preparation_Script>().Reset_Timer_Boss();
                else
                    preparation.GetComponent<Preparation_Script>().Reset_Timer();
                Wave_Number++;

                //Debug.Log("I do " + Wave_Number);
            }
            if (!preparation.inPreparation && !_isWorking)
            {
                _isWorking = true;
                Rise_Wave();
            }
            else if (preparation.inPreparation && _isWorking)
            {
                _isWorking = false;
            }

            if (Wave_Number == Waves.Length-1 && NeedToKill==0)
            {
                Debug.Log("Win");
                isWavesEnd = true;
            }            
        }
    }

    public void Rise_Wave()
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
        
    }   
        
}

    /* private IEnumerator SpawnEnemyInWave()
     {
         if (_enemiesLeftToSpawn > 0)
         {
             yield return new WaitForSeconds(3);


             Instantiate(waves[_currentWaveIndex].waves[_currentEnemyIndex].Enemy,
               waves[_currentWaveIndex].waves[_currentEnemyIndex].Portal.transform.position, Quaternion.identity);

             _enemiesLeftToSpawn--;
             _currentEnemyIndex++;
             StartCoroutine(SpawnEnemyInWave());
         }
         else
         {
             if (_currentWaveIndex < waves.Length - 1)
             {
                 _currentWaveIndex++;
                 _enemiesLeftToSpawn = waves[_currentWaveIndex].waves.Length;
                 _currentEnemyIndex = 0;
             }
         }
     }

     public void LaunchWave()
     {
         StartCoroutine(SpawnEnemyInWave());
     }*/


[System.Serializable]
public class Waves
{
    public WaveSettings[] waves;
    public bool IsBoss = false;
}

[System.Serializable]
public class WaveSettings
{
    public GameObject Enemy;
    [SerializeField] private int _min_Count_Enemy;
    [SerializeField] private int _max_Count_Enemy;
    public GameObject Portal;

    public int GetEnemyCount()
    {
        return Random.Range(_min_Count_Enemy, _max_Count_Enemy+1);
    }
}

