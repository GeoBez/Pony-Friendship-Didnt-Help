using System.Collections.Generic;
using UnityEngine;

public class FreezeUlt : Ult
{
    [Header("Поля для Freaze Ult")]
    public Ice iseEffect;
    public ParticleSystem iceDestroyParticle;
    public LayerMask mask;
    private Camera _camera;
    private List<IFreezable> _freezableEnemy;
    [Range(1, 99)] public float ultDamage;
    new void Start()
    {
        base.Start();
        _camera = Camera.main;
        _freezableEnemy = new List<IFreezable>();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (isUltEnd)
        {
            foreach (var f in _freezableEnemy)
            {
                if (f.ToString() != "null")
                {
                    f.FreezingEnd(iceDestroyParticle);
                }
            }
            isUltEnd = false;
        }
    }
    new public void TryUse()
    {
        if (!base.TryUse()) return;

        if (_camera == null)
        {
            Debug.Log("Camera is null");
            return;
        }

        PlayerMovement.instance.ChangeState(PlayerMovement.StateAnimation.Ability);
        _freezableEnemy.Clear();

        var w = Screen.width;
        var h = Screen.height;

        var lowerLeftCorner = _camera.ScreenToWorldPoint(new Vector2(0, 0));
        var upperRightCorner = _camera.ScreenToWorldPoint(new Vector2(w, h));

        var enemy = Physics2D.OverlapAreaAll(lowerLeftCorner, upperRightCorner, mask);

        foreach (var e in enemy)
        {
            var freezable = e.GetComponent<IFreezable>();
            if (freezable != null)
            {
                _freezableEnemy.Add(freezable);
                e.GetComponent<Enemy>()?.TakeHit(ultDamage);
                freezable.FreezingAnimationStart();
            }
        }
    }
}
