using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_Speed_Script : MonoBehaviour
{
    public float speed;
    private float defaultSpeed;
    public float returnSpeedTime;
    private float defaultTime;

    private void Start()
    {
        if(gameObject.tag == "Player")
        {
            speed = GetComponent<PlayerMovement>().speed;
        }
        else if (gameObject.tag == "Enemy" || gameObject.tag == "Tower Enemy" || gameObject.tag == "Boss")
        {
            speed = GetComponent<Enemy>().Speed;
        }
        defaultSpeed = speed;
        defaultTime = returnSpeedTime;
    }

    void Update()
    {
        if (speed != defaultSpeed)
        {
            returnSpeedTime -= Time.deltaTime;
            if (returnSpeedTime < 0)
            {
                if (gameObject.tag == "Player")
                {
                    GetComponent<PlayerMovement>().speed = defaultSpeed;
                }
                else if (gameObject.tag == "Enemy" || gameObject.tag == "Tower Enemy" || gameObject.tag == "Boss")
                {
                    GetComponent<Enemy>().Speed = defaultSpeed;
                }
                speed = defaultSpeed;
                returnSpeedTime = defaultTime;
            }
        }
    }
}
