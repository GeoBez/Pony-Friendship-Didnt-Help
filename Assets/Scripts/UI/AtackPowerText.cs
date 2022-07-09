using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtackPowerText : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = string.Format("�����: {0}", 1);
    }

    public void UpdateText(int damage)
    {
        text.text = string.Format("�����: {0}", damage);
    }
}
