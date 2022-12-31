using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Collider2D slimeCollider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        slimeCollider = GetComponent<Collider2D>();
    }

    public float Health
    {
        set
        {
            health = value;

        }
        get
        {
            return health;
        }
    }
    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Defeated();
        }
    }
    public float health = 3;

    public void Defeated()
    {
        animator.SetBool("Death", true);
    }
    public void Death()
    {
        animator.enabled = false;
        slimeCollider.enabled = false;
    }
}
