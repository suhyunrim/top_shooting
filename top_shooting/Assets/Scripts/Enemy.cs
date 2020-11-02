using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CollisionObject
{
    [SerializeField]
    private int hp = 3;

    private void Start()
    {
        MovementVector = new Vector2(0, -0.05f);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHP(int value = 1)
    {
        hp -= value;
        if (hp == 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefabs/Explosion") as GameObject;
            var destroyEffect = Instantiate(destroyEffectPrefab, transform);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            Invoke("DestroySelf", 1f);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}