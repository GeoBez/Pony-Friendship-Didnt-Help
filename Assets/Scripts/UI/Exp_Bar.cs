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
        Debug.Log($"Exp: {PlayerStatistics.Experience}, ExpCurForLVL: {PlayerStatistics.ExpCurLevel}, ExpNextForLVL: {PlayerStatistics.ExpNextLevel}, LVL: {PlayerStatistics.Level}, Card: {PlayerStatistics.Received�ards}");
        fill_Value.value = PlayerStatistics.Experience - PlayerStatistics.ExpCurLevel;
        fill_Value.maxValue = PlayerStatistics.ExpNextLevel - PlayerStatistics.ExpCurLevel;
    }
}
