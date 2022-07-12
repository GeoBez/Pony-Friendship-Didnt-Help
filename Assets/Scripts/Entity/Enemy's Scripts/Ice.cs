using System;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private float _lifeTime;

    void Start()
    {
        _lifeTime = 3;
        Invoke(nameof(DestroyIce), _lifeTime);
    }

    private void DestroyIce()
    {
        Destroy(gameObject);
    }
}