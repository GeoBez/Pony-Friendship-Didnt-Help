using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    public void StopPlayerMovement()
    {
        playerMovement.enabled = false;
    }
    public void ContinuePlayerMovement()
    {
        playerMovement.enabled = true;
    }

}
