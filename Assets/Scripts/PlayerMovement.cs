using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    public enum ControlType { PC, Phone }

    [Range(0, 3)] public int joystickNum;
    [SerializeField] private Joystick[] _joysticks;
    private Joystick _joystick;
    [SerializeField] private ControlType _controlType;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelicity;
    private bool facingRight;

    void Start()
    {
        _joystick = _joysticks[joystickNum];
        _joysticks[joystickNum].gameObject.SetActive(true);

        _controlType = ControlType.Phone;
        rb = GetComponent<Rigidbody2D>();
        if (_controlType == ControlType.PC) { _joystick.gameObject.SetActive(false); }
    }

    void Update()
    {
        switch (_controlType)
        {
            case ControlType.PC:
                moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                break;
            case ControlType.Phone:
                moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
                break;
        }
        moveVelicity = moveInput.normalized * speed;
        if (facingRight && moveInput.x < 0) { Flip(); }
        else if (!facingRight && moveInput.x > 0) { Flip(); }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelicity * Time.deltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
