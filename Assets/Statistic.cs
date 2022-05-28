using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistic : MonoBehaviour
{
    public Text timeText;
    public Text enemyDeathCountText;
    public Text enemyDeathCountTextVictMenu;
    public static int enemyDeathCount;
    private float _startTime;
    private bool _finished;
    void Start()
    {
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeText.gameObject.activeInHierarchy && !_finished)
        {
            _finished = true;
            timeText.text = $"Вы продержались {Mathf.Round((Time.time - _startTime)/60)} минут.\nПопробуйте снова";
            enemyDeathCountText.text = enemyDeathCount.ToString();
            enemyDeathCountTextVictMenu.text = enemyDeathCount.ToString();
        }
    }
}
