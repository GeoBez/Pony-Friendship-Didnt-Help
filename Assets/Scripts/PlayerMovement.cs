using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    private float defaultSpeed;

    #region Animation

    private Animator animator;
    private float x, y;

    #endregion

    public float returnSpeedTime;
    private float defaultTime;

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


    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        joystickNum = lastJoysticNum = PlayerPrefs.HasKey("joystickType") ? PlayerPrefs.GetInt("joystickType") : 0;
        SwitchJoystick(joystickNum);

        _controlType = ControlType.Phone;
        rb = GetComponent<Rigidbody2D>();
        if (_controlType == ControlType.PC) { _joystick.gameObject.SetActive(false); }
        defaultTime = returnSpeedTime;
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
        if (x != 0 && y != 0) 
        {   
            animator.SetBool("isMoving", true);
            shotPoint.localPosition = new Vector2(x, y);
        }
        else
        {
            shotPoint.localPosition = new Vector2(0, -1);
            animator.SetBool("isMoving", false);
        }


        shotPoint.localPosition = new Vector2(x, y);

        moveVelicity = moveInput.normalized * speed;

        if(speed != defaultSpeed)
        {
            returnSpeedTime -= Time.deltaTime;
            if(returnSpeedTime < 0)
            {
                speed = defaultSpeed;
                returnSpeedTime = defaultTime;
            }
        }
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
