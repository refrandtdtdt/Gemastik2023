using UnityEngine;

public class Player : Entity
{
    private bool canMove = true;
    private bool isMoving = false;
    private bool isJumping = false;
    private Animator animator;
    [SerializeField] protected LayerMask enemyMask;

    public bool CanMove { get => canMove; set => canMove = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsJumping { get => isJumping; set => isJumping = value; }
    public Animator Animator { get => animator; set => animator = value; }

    // Player's Action

    override
    public void Move()
    {
        if (MadepMana == Hadap.Kiri)
        {
            //Vector3 destination = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, destination, Speed*Time.deltaTime*2);
            //transform.position += new Vector3(-Speed*Time.deltaTime, 0);
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            transform.localScale = new Vector3(-Scale.x, Scale.y, Scale.z);
            
            return;
        }
        if (MadepMana == Hadap.Kanan)
        {
            //Vector3 destination = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            //transform.position = Vector3.MoveTowards(transform.position, destination, Speed * Time.deltaTime*2);
            //transform.position += new Vector3(Speed * Time.deltaTime, 0);
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
            return;
        }
        
    }
    /**
     * Jump action for player
     */
    public void Jump()
    {
        if (isJumping && (JumpCount > 0))
        {
            //Debug.Log("Kuduna Loncat euy");
            //rb.AddForce(new Vector2(0, JumpDistance), ForceMode2D.Impulse);
            this.Animator.Play("Rama_Jump");
            this.Animator.SetBool("Jumping", true);
            rb.velocity = new Vector2(rb.velocity.x, JumpDistance);
            JumpCount--;
        }
        if (CheckGround()) {
            this.Animator.SetBool("Jumping", false);
            IsJumping = false;
            JumpCount = 1;
        }
            
    }


    protected bool CheckGround()
    {
        Collider2D playerCollider = GetComponent<BoxCollider2D>();
        Vector2 raycastPos = playerCollider.bounds.center;
        float raycastDist = playerCollider.bounds.extents.y + 0.1f;

        RaycastHit2D hit = Physics2D.BoxCast(raycastPos, playerCollider.bounds.size, 0f, Vector2.down, raycastDist, this.LayerMask);
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;

        }
        Debug.DrawRay(raycastPos + new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, 0), Vector2.down * raycastDist, rayColor);
        Debug.DrawRay(raycastPos - new Vector2(playerCollider.bounds.extents.x, raycastDist), 2 * raycastDist * Vector2.right, rayColor);
        return hit.collider != null;
    }

    public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, AttackRadius, enemyMask);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attacking");
            this.Animator.Play("Rama_MeleeAttack");
            foreach (Collider2D enemy in enemies)
            {
                Debug.Log("Hit enemy");
                Enemy theEnemy = enemy.GetComponent<Enemy>();
                theEnemy.SetHealth(theEnemy.GetHealth() - AttackPower);
            }
        }
    }

    public override void Die()
    {
        transform.position = new Vector2(5.75f, 1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, AttackRadius);
    }
}
