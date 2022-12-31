using UnityEngine;

public class Enemy : MonoBehaviour
{

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
        Destroy(gameObject);
    }
}
