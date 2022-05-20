using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UltLinkedUpgrades : MonoBehaviour
{
    public Player player;
    new public string name;
    public string description;
    public float coolDown;
    protected float _currentCoolDown;
    public float duration;
    protected float _currentDuration;
    private bool _isNeedRollback;
    private bool _isActive;
    protected bool isUpgradeEnd;

    protected void Start()
    {
        _currentCoolDown = coolDown;
        _currentDuration = duration;
    }

    protected void Update()
    {
        if (_isNeedRollback)
        {
            _currentCoolDown += Time.deltaTime;
        }
        if (_currentCoolDown >= coolDown)
        {
            _isNeedRollback = false;
            _currentCoolDown = coolDown;
        }

        if(_isActive)
        {
            _currentDuration -= Time.deltaTime;
            if (_currentDuration <= 0)
            {
                _isActive = false;
                isUpgradeEnd = true;
                _currentDuration = duration;
            }
        }
    }

    protected bool IsCanNotUse(){
        return _currentCoolDown != coolDown;
    }

    public virtual bool TryUse(){
        
        if (IsCanNotUse()) return false;

        _currentCoolDown = 0;
        _currentDuration = duration;
        _isNeedRollback = true;
        _isActive = true;
        return true;
    }
}
