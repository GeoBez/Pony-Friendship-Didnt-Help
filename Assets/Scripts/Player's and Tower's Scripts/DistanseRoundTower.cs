using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanseRoundTower : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Weapon towerWeapon;
    [SerializeField] private Player player;
    public float accuracyFactor;


    void Start()
    {
        towerWeapon = tower.GetComponentInChildren<Weapon>();
        transform.localScale = new Vector2(towerWeapon.detectionDistance * accuracyFactor, towerWeapon.detectionDistance * accuracyFactor);
    }
    void FixedUpdate(){
        if (player != null) transform.position = player.transform.position;
    }
}
