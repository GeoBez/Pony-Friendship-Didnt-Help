using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Dropdown dropdown;

    public void Start()
    {
        if (dropdown != null) dropdown.value = PlayerPrefs.HasKey("joystickType") ? PlayerPrefs.GetInt("joystickType") : 0;
    }
    public void SwitchJoystick(int currentJoystickIndex)
    {
        PlayerPrefs.SetInt("joystickType", currentJoystickIndex);
    }
}
