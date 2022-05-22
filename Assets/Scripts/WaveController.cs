using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Waves[] Waves;

    public int Wave_Number;
    public int NeedToSpawn;


    public Preparation_Script preparation;

    private void Start()
    {
        preparation = GameObject.FindGameObjectWithTag("Preparation").GetComponent<Preparation_Script>();
        Wave_Number = 0;

        //LaunchWave();
    }

    public void Rise_Wave_Number()
    {
        for (int i =0; i < Waves[Wave_Number].waves.Length; i++)
        {
            NeedToSpawn = Waves[Wave_Number].waves[i].GetEnemyCount();

            //Enemy_Spawn(Waves[Wave_Number].waves[i].Enemy);
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
}

[System.Serializable]
public class Waves
{
    public WaveSettings[] waves;
}

[System.Serializable]
public class WaveSettings
{
    public GameObject Enemy;
    [SerializeField] private int _min_Count_Enemy;
    [SerializeField] private int _max_Count_Enemy;
    public GameObject Portal;

    public int SpawnDelay;

    public int GetEnemyCount()
    {
        return Random.Range(_min_Count_Enemy, _max_Count_Enemy+1);
    }
}

