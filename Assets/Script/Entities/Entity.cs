using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    //attribute
    private int id;
    private string description;
    [SerializeField] private int health;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speed;
    [SerializeField] private float jumpDistance;
    [SerializeField] private int attackPower;
    public GameObject attackPoint;
    [SerializeField] private float attackRadius;
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCollider;
    private int maxHealth;
    [SerializeField] private int jumpCount = 1;


    // getter and setter

    public int AttackPower { get => attackPower; set => attackPower = value; }
    public float JumpDistance { get => jumpDistance; set => jumpDistance = value; }
    public float Speed { get => speed; set => speed = value; }
    public LayerMask LayerMask { get => layerMask; set => layerMask = value; }
    public float AttackRadius{get => attackRadius; set => attackRadius = value;}
    public int JumpCount
    {
        get => jumpCount;
        set
        {
            jumpCount = value;
            if (jumpCount < 0)
            {
                jumpCount = 0;
            }
        }
    }

    public int GetId()
    {
        return id;
    }
    public string GetDescription()
    {
        return description;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescription(string description)
    {
        this.description = description;
    }
    public void SetHealth(int health)
    {
        this.health = health;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            Debug.Log($"{gameObject.name} Die!");
            Destroy(gameObject);
        }
    }
    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        if(maxHealth < health)
        {
            health = maxHealth;
        }
    }

    public abstract void Move();
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
