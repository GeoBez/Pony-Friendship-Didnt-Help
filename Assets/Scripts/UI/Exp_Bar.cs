using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���� ����� ����� �� ������, ��� ����� ����������� ����� �����. ������ ���� �� ������.
public class Exp_Bar : MonoBehaviour
{
    Slider fill_Value;
    public static Exp_Bar instance { get; private set; }

    void Start()
    {
        instance = this;
        fill_Value = GetComponent<Slider>();
        fill_Value.value = 0;
    }
    public void Update_Bar()
    {
        Debug.Log($"Exp: {PlayerStatistic.Experience}, ExpCurForLVL: {PlayerStatistic.ExpCurLevel}, ExpNextForLVL: {PlayerStatistic.ExpNextLevel}, LVL: {PlayerStatistic.Level}, Card: {PlayerStatistic.Received�ards}");
        
        fill_Value.value = PlayerStatistic.Experience - PlayerStatistic.ExpCurLevel;
        fill_Value.maxValue = PlayerStatistic.ExpNextLevel - PlayerStatistic.ExpCurLevel;
    }
}
