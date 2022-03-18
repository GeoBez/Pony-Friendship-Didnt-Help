using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_Tracker : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 Screen_Mouse_Pos = Input.mousePosition;
        Vector3 World_Mouse_Pos = _camera.ScreenToWorldPoint(Screen_Mouse_Pos);
        transform.LookAt(new Vector3(0, 0, World_Mouse_Pos.z));
    }
}
