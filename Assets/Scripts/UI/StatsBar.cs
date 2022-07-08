using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private Text hpCount;
    private RectTransform _rectTransform;

    void Awake(){
        hpCount = GetComponentInChildren<Text>();
        _rectTransform = GetComponent<RectTransform>();
    }
    
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
        
        if (hpCount != null) hpCount.text = $"{slider.maxValue}/{slider.maxValue}";
    }
    public void SetValue(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (hpCount != null) hpCount.text = $"{value}/{slider.maxValue}";
    }
    
    void Update()
    {
        if (_rectTransform != null)
        {
            _rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
