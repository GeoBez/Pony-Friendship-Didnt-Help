using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltYouWillNotPass : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private Image image;
    [SerializeField] private Text text;

    private bool _isNeedRollback;
    public float coolDown;
    private bool _isUltActive;
    private float _currentCoolDown;

    public float duration;
    private float _currentDuration;

    void Start()
    {
        _currentCoolDown = coolDown;
        _currentDuration = duration;
        image.fillAmount = 1;
    }

    void Update()
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
                _currentDuration = duration;
                text.gameObject.SetActive(false);
                weapon.whatIsAttack = LayerMask.GetMask("Enemy");
            }
        }

    }

    public void TryUse()
    {
        if(_currentCoolDown == coolDown)
        {
            weapon.whatIsAttack = LayerMask.GetMask("Tower Enemy");
            _currentCoolDown = 0;
            image.fillAmount = 0;
            _isNeedRollback = true;
            _isUltActive = true;
            text.gameObject.SetActive(true);
        }
    }
}
