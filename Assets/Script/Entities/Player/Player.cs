using UnityEngine;

public class Player : Entity
{
    [SerializeField] protected LayerMask enemyMask;
    // Player's Action

    override
    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-Speed, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(Speed, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    /**
     * Jump action for player
     */
    public void Jump()
    {
        if (CheckGround() && (JumpCount > 0) && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Kuduna Loncat euy");
            rb.AddForce(new Vector2(0, JumpDistance), ForceMode2D.Impulse);
            JumpCount--;
        }
        if (CheckGround()) JumpCount = 1;
    }


    private bool CheckGround()
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
