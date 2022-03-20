using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Controller : MonoBehaviour
{
    CinemachineVirtualCamera vCamera;
    GameObject Player;

    private void Start()
    {
        vCamera = GameObject.FindGameObjectWithTag("vCamera").GetComponent<CinemachineVirtualCamera>();
        Player = GameObject.FindGameObjectWithTag("Player");
        vCamera.Follow = Player.transform;
    }
}