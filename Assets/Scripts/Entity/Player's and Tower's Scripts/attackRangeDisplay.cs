using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRangeDisplay : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private Weapon towerWeapon;
    private GameObject distanceRound;
    [SerializeField] private GameObject distanceRoundPrefab;
    public float accuracyFactor;
    
    void Awake()
    {
        towerWeapon = tower.GetComponentInChildren<Weapon>();
        if (distanceRound == null)
        {
            distanceRound = Instantiate(distanceRoundPrefab, tower.transform, false);
            distanceRound.SetActive(false);
        }
            
    }

    void Update()
    {
        distanceRound.transform.localScale = new Vector2(towerWeapon.detectionDistance * accuracyFactor, towerWeapon.detectionDistance * accuracyFactor);
    }

    void OnMouseEnter()
    {
        distanceRound.SetActive(true);
    }

    void OnMouseExit()
    {
        distanceRound.SetActive(false);
    }
}
