using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CollisionObject
{
    private void Start()
    {
        MovementVector = new Vector2(0, 0.1f);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().DecreaseHP();
            Destroy(gameObject);
        }
    }
}