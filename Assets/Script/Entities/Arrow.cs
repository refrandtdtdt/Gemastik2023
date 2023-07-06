using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool kenaCollider = false;
    public Bow bow;
    private float startTime;
    [SerializeField] private int damage = 0;
    public int Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float angle;
        if (!kenaCollider)
        {
            angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        kenaCollider = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        //cek apakah kena ke enemy
        if (collider.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("Musuh Kena Hit!");
            enemy.SetHealth(enemy.GetHealth() - Damage);

        }
        startTime = Time.time;
    }
}
