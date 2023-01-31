using UnityEngine;

public class OldEnemy : MonoBehaviour
{
    Animator animator;
    Animation slimeAniimation;
    Collider2D slimeCollider;
    public AiChase aiChase;
    SpriteRenderer spriteRenderer;
    public int idleLength;
    public int bounces;
    public float health;
    private float loops;


    private void Start()
    {
        animator = GetComponent<Animator>();
        slimeCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slimeAniimation = GetComponent<Animation>();
        loops = 0;
        Idle();
    }

 
    private void FixedUpdate()
    {
        Behavior();
    }

    public void Behavior()
    {
        if (health <= 0)
        {
            Defeated();
        }
        else
        {
            aiChase.Patrol();
        }
    }

    public void Defeated()
    {
        animator.SetBool("dead", true);
    }
    public void Death()
    {
        animator.enabled = false;
        slimeCollider.enabled = false;
        spriteRenderer.sortingOrder -= spriteRenderer.sortingOrder;
    }
    public void Damage()
    {
        slimeAniimation.Play("damage");
        aiChase.canMove = false;
        loops = 0;

    }
    public void Idle()
    {

        if (loops < idleLength)
        {
            IdleTimer();
            aiChase.canMove = false;
            animator.SetBool("isMoving", false);
        }
        else
        {
            loops = 0;
            Bounce();

        }

    }
    public void Bounce()
    {
        if (loops < bounces)
        {
            IdleTimer();
            aiChase.canMove = true;
            animator.SetBool("isMoving", true);
        }
        else
        {
            loops = 0;
            Idle();

        }
    }
    public void IdleTimer()
    {
        loops += 1;
        print(loops);
    }

}
