using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rama : Player
{
    void Start()
    {
        SetId(1);
        SetDescription("Karakter utama dari ini, memiliki senjata panah idk the name lmao");
        Speed = 0.1f;
        JumpDistance = 10;
        SetMaxHealth(100);
        SetHealth(100);
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        MadepMana = Hadap.Kanan;
    }

    void Update()
    {
        if (CanMove)
        {
            Move();
            Jump();
            Attack();
        }
    }
}
