using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Waves[] waves;
}

[System.Serializable]
public class Waves
{
    public WaveSettings[] waves;
}

[System.Serializable]
public class WaveSettings
{
    public GameObject enemy;
    public int Min_Count_Enemy;
    public int Max_Count_Enemy;
    public GameObject Portal;
}

