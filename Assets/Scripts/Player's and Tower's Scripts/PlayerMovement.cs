using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Animation

    private StateAnimation stateAnimation;

    public enum StateAnimation
    {
        idle,
        Run,
        Ability,
    }
    private Dictionary<StateAnimation, string> NameAnimation = new Dictionary<StateAnimation, string>
    {
        [StateAnimation.idle] = "player_idle",
        [StateAnimation.Run] = "player_run",
        [StateAnimation.Ability] = "player_ultUsing"
    };

    private Animator animator;

    private float x, y;

    private void SetStateIdle()
    {
        ChangeState(StateAnimation.idle);
    }
    public void ChangeState(StateAnimation state)
    {
        if (state == stateAnimation) return;
        if (Enum.IsDefined(typeof(StateAnimation), state.ToString()))
        {
            stateAnimation = state;
            animator.Play(NameAnimation[stateAnimation]);
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (state != StateAnimation.idle && state != StateAnimation.Run)
                Invoke(nameof(SetStateIdle), stateInfo.length);
            return;
        }
        stateAnimation = StateAnimation.idle;
        Debug.LogError($"State Is Not Defined: {state}");
        animator.Play(NameAnimation[stateAnimation]);
    }

    #endregion

    public enum ControlType { PC, Phone }

    #region JoyStick

    private int joystickNum;
    [SerializeField] private Joystick[] _joysticks;
    private Joystick _joystick;
    [SerializeField] private ControlType _controlType;

    int lastJoysticNum;

    private void SwitchJoystick(int joystickNum)
    {
        _joystick = _joysticks[joystickNum];
        _joysticks[lastJoysticNum].gameObject.SetActive(false);
        _joysticks[joystickNum].gameObject.SetActive(true);
        lastJoysticNum = joystickNum;
    }

    #endregion

    private Rigidbody2D rb;

    private Vector2 moveInput;

    private Vector2 moveVelicity;

    public bool isMovement { get { return moveVelicity != new Vector2(0, 0); } }

    public Transform shotPoint;

    public Transform stats;

     public static PlayerMovement instance;

    void Start()
    {
        instance = this;
        animator = GetComponentInChildren<Animator>();

        joystickNum = lastJoysticNum = PlayerPrefs.HasKey("joystickType") ? PlayerPrefs.GetInt("joystickType") : 0;
        SwitchJoystick(joystickNum);

        _controlType = ControlType.PC;
        rb = GetComponent<Rigidbody2D>();
        if (_controlType == ControlType.PC) { _joystick.gameObject.SetActive(false); }
    }

    private void Movement()
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
        moveVelicity = moveInput.normalized * Player.MainPlayer.Speed;
        ChangeScale(x > 0);
    }
    private void ChangeScale(bool DirectionX)
    {
        if (x == 0) return;
        int dir = DirectionX ? 1 : -1;
        transform.localScale = new Vector3(dir, 1, 1);
        stats.localScale = new Vector3(0.5f * dir, .5f, 1);
    }

    void Update()
    {
        if (stateAnimation == StateAnimation.idle || stateAnimation == StateAnimation.Run)
            Movement();
        else moveVelicity = Vector2.zero;

        if (isMovement)
        {
            ChangeState(StateAnimation.Run);
        }
        else if (stateAnimation == StateAnimation.Run)
            SetStateIdle();
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelicity * Time.deltaTime);
    }

    
}
