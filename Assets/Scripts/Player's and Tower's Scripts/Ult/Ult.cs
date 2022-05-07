using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ult : MonoBehaviour
{
    [SerializeField] private Image image;

    private bool _isNeedRollback;
    public float coolDown;
    private bool _isUltActive;
    private float _currentCoolDown;

    [Range(1, 60)]public float duration;
    protected float _currentDuration;
    protected bool isUltEnd;

    public void Start()
    {
        _currentCoolDown = coolDown;
        _currentDuration = duration;
        image.fillAmount = 1;
    }

    public void Update()
    {
        if (_isNeedRollback)
        {
            _currentCoolDown += Time.deltaTime;
            image.fillAmount = _currentCoolDown / coolDown;
        }
        if (_currentCoolDown >= coolDown)
        {
            _isNeedRollback = false;
            _currentCoolDown = coolDown;
        }

        if(_isUltActive)
        {
            _currentDuration -= Time.deltaTime;
            if (_currentDuration <= 0)
            {
                _isUltActive = false;
                isUltEnd = true;
                _currentDuration = duration;
            }
        }

    }

    public bool TryUse()
    {
        if (_currentCoolDown != coolDown) return false;
        
        _currentCoolDown = 0;
        image.fillAmount = 0;
        _isNeedRollback = true;
        _isUltActive = true;
        return true;
    }
}
