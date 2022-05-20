using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Laser : MonoBehaviour
{
    Transform Player;

    public Vector3 angle;

    public float Time_Btw_Spawns;
    public GameObject Laser;

    float default_Btw_Spawns;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        default_Btw_Spawns = Time_Btw_Spawns;
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((Player.position.y - transform.position.y), (Player.position.x - transform.position.x)) * Mathf.Rad2Deg);
        Time_Btw_Spawns -= Time.deltaTime;
        if (Time_Btw_Spawns <= 0)
        {
            angle = transform.eulerAngles;
            Instantiate(Laser, transform.position, Quaternion.identity);
            Time_Btw_Spawns = default_Btw_Spawns;
        }
    }
}
