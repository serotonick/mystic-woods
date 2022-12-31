using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 3;
    Vector2 rightAttackOffset;
    public Collider2D swordCollider;
    private void Start()
    {
        rightAttackOffset = transform.position;
        swordCollider.enabled = false;
    }
    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        print("Right");
    }
    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        print("Left");

    }
    public void StopAttack()
    {
        swordCollider.enabled = false;
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
                print(enemy.health);
            }
        }
    }
}