using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 3;
    Vector2 attackOffset;
    public Collider2D swordHitboxL;
    public Collider2D swordHitboxR;
    public Collider2D swordHitboxU;
    public Collider2D swordHitboxD;
    private void Start()
    {
        attackOffset = transform.position;
        swordHitboxR.enabled = false;
        swordHitboxL.enabled = false;
        swordHitboxU.enabled = false;
        swordHitboxD.enabled = false;
    }
    public void AttackRight()
    {
        swordHitboxR.enabled = true;
        //transform.localPosition = attackOffset;
    }
    public void AttackLeft()
    {
        swordHitboxL.enabled = true;
        //transform.localPosition = attackOffset;

    }
    public void AttackDown()
    {
        swordHitboxD.enabled = true;
       // transform.localPosition = attackOffset;
    }
    public void AttackUp()
    {
        swordHitboxU.enabled = true;
        //transform.localPosition = attackOffset;
    }
    public void StopAttack()
    {
        swordHitboxR.enabled = false;
        swordHitboxL.enabled = false;
        swordHitboxU.enabled = false;
        swordHitboxD.enabled = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Deal damage to the enemy
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.health -= damage;
                           }
                 }
    }
}