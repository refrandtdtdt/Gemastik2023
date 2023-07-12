using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Rama : Player
{
    void Start()
    {
        SetId(1);
        SetDescription("Karakter utama dari ini, memiliki senjata panah idk the name lmao");
        Speed = 7.5f;
        JumpDistance = 11f;
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
            }
            else if (Input.GetKey(KeyCode.D)) 
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
            if (IsPulling) { return;  }
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
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsMoving || IsPulling) return;
        if (mousePos.x >= transform.position.x)
        {
            transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
            MadepMana = Hadap.Kanan;
        }
        else
        {
            transform.localScale = new Vector3(-Scale.x, Scale.y, Scale.z);
            MadepMana = Hadap.Kiri;
        }
    }

    private void FixedUpdate()
    {
        Multiplier *= -1;
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
