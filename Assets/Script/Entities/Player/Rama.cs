using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rama : Player
{
    void Start()
    {
        SetId(1);
        SetDescription("Karakter utama dari ini, memiliki senjata panah idk the name lmao");
        Speed = 10f;
        JumpDistance = 12.5f;
        SetMaxHealth(100);
        SetHealth(100);
        AttackPower = 20;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        MadepMana = Hadap.Kanan;
        Scale = transform.localScale;
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (CanMove)
        {
            if (Input.GetKey(KeyCode.A)){
                MadepMana = Hadap.Kiri;
                IsMoving = true;
                if (!Animator.GetBool("Moving"))
                    Animator.SetBool("Moving", true);
            }else if (Input.GetKey(KeyCode.D)) 
            {
                MadepMana = Hadap.Kanan;
                IsMoving = true;
                if (!Animator.GetBool("Moving"))
                    Animator.SetBool("Moving", true);
            }
            else
            {
                IsMoving = false;
                if(Animator.GetBool("Moving"))
                    Animator.SetBool("Moving", false);
            }
            if (Input.GetKeyDown(KeyCode.Space) && CheckGround()) {
                IsJumping = true;
            }
            Attack();
        }
        else
        {
            IsMoving = false;
            if (Animator.GetBool("Moving"))
                Animator.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
        if (IsMoving)
        {
            Move();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        Jump();
    }
}
