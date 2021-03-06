using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public float speed = 8;
    private float defaultSpeed;
    [SerializeField] GameObject MiniMap;
    #region Animation

    private Animator animator;
    private float x, y;

    #endregion

    public enum ControlType { PC, Phone }

    #region JoyStick
    private int joystickNum;
    [SerializeField] private Joystick[] _joysticks;
    private Joystick _joystick;
    [SerializeField] private ControlType _controlType;

    int lastJoysticNum;
    #endregion

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelicity;

    public Transform shotPoint;

    public Transform stats;

    void Start()
    {
        speed = GetComponent<Player>().Speed;

        animator = GetComponentInChildren<Animator>();

        joystickNum = lastJoysticNum = PlayerPrefs.HasKey("joystickType") ? PlayerPrefs.GetInt("joystickType") : 0;
        SwitchJoystick(joystickNum);

        _controlType = ControlType.PC;
        rb = GetComponent<Rigidbody2D>();
        if (_controlType == ControlType.PC) { _joystick.gameObject.SetActive(false); }
        defaultSpeed = speed;        
    }

    void Update()
    {
        switch (_controlType)
        {
            case ControlType.PC:
                moveInput = new Vector2(x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical"));
                break;
            case ControlType.Phone:
                moveInput = new Vector2(x = _joystick.Horizontal, y = _joystick.Vertical);
                break;
        }

        animator.SetFloat("X", x);
        animator.SetFloat("Y", y);
        if (x != 0 || y != 0) 
        {   
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        moveVelicity = moveInput.normalized * speed;

        if (moveVelicity != new Vector2(0, 0))
        {
            animator.Play("player_run");
        }
        else
        {
            animator.Play("player_idle");
        }

        if(speed != defaultSpeed)
        {
            GetComponent<Return_Speed_Script>().speed = speed; 
        }

        if(x>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            stats.localScale = new Vector3(0.5f, .5f, 1);
        }
        else if(x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            stats.localScale = new Vector3(-0.5f, .5f, 1);
        }

        if (Input.GetKey(KeyCode.Space))
            MiniMap.SetActive(true);
        else MiniMap.SetActive(false);
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelicity * Time.deltaTime);
    }

    private void SwitchJoystick(int joystickNum)
    {
        _joystick = _joysticks[joystickNum];
        _joysticks[lastJoysticNum].gameObject.SetActive(false);
        _joysticks[joystickNum].gameObject.SetActive(true);
        lastJoysticNum = joystickNum;
    }
}
