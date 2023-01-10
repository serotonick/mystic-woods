using UnityEngine;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float Speed;
    public float FollowDistance;
    public bool canMove;
    SpriteRenderer spriteRenderer;
    public OldEnemy enemy;

    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        spriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true;

    }

    // Update is called once per frame

    public void Patrol()
    {
        if (canMove == true && distance < FollowDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Speed * Time.deltaTime);
        };
        if (canMove == true && transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (canMove == true && transform.position.x > player.transform.position.x)
        {
            spriteRenderer.flipX = true;
        };

    }
}
