using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    protected UnityEvent<int> EventChangeDamage;

    protected UnityEvent EventTakeHit;

    private StatsBar healthBar;

    [SerializeField] private float maxHealth = 10;
    public float MaxHealth
    {
        get => maxHealth; set
        {
            if (value > 0)
            {
                Health = value - health;
                maxHealth = value;
                healthBar.SetMaxValue(MaxHealth);
            }
        }
    }
    protected abstract void OnAwake();
    private void Awake()
    {
        EventChangeDamage = new UnityEvent<int>();
        EventTakeHit = new UnityEvent();
        healthBar = GetComponentInChildren<StatsBar>();
        MaxHealth = maxHealth;
        Health = MaxHealth;
        OnAwake();
    }
    [SerializeField] private float health;
    public float Health
    {
        get => health;
        set
        {
            if (value <= MaxHealth)
            {
                health = value;
                healthBar.SetValue(value);
            }
        }
    }
    private float speed = 11;
    public float Speed
    {
        get => speed;
        set
        {
            speed = value;
            GetComponent<PlayerMovement>().speed = value;
        }
    }
    public int Damage
    {
        get => damage; set
        {
            if (value > 0)
            {
                damage = value;
                EventChangeDamage.Invoke(value);
            }

        }
    }
    [SerializeField] private int damage;
    public abstract void Death();
    protected bool isImmortality;
    public void TakeHit(float damage)
    {
        if (isImmortality) return;

        EventTakeHit.Invoke();
        Health -= damage;
        if (Health <= 0)
        {
            Death();

            Destroy(gameObject);
        }
    }
}
