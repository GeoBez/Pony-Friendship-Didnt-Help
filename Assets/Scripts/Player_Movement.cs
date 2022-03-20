using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed;
    private float move_Input = 1;
    private Rigidbody2D rb;

    float default_Speed;
    public float time;
    float default_Time;

    Camera _camera;

    public Animator Anim_Legs;

    Vector3 World_Mouse_Pos;
    Vector3 direct;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        default_Speed = speed;
        default_Time = time;
    }

    void FixedUpdate()
    {
        if (speed < default_Speed)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else if(time<0)
            {
                speed = default_Speed;
                time = default_Time;
            }
        }

        rb.velocity = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(move_Input * speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(move_Input * -speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, move_Input * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(rb.velocity.x, move_Input * -speed);
        }

        if (rb.velocity == new Vector2(0, 0))
        {
            Anim_Legs.Play("Player_legs_idle");
        }

        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            Anim_Legs.Play("Player_Legs_Walking");
        }
        Rotation_Character();
    }

    void Rotation_Character()
    {
        World_Mouse_Pos = _camera.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z-_camera.transform.position.z));
        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((World_Mouse_Pos.y - transform.position.y), (World_Mouse_Pos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}