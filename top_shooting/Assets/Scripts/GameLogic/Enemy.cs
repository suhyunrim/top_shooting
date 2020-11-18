using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CollisionObject
{
    [SerializeField]
    private int hp = 3;

    private int enemyDataKey;

    private EnemyData Data => EnemyData.Get(enemyDataKey);

    private void Awake()
    {
        enemyDataKey = Random.Range(1, EnemyData.All.Length + 1);
        hp = Data.Hp;

        MovementVector = new Vector2(0, -0.02f);

        var sprite = Resources.Load<Sprite>($"Images/Enemies/{Data.ImageName}");
        GetComponent<SpriteRenderer>().sprite = sprite;
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

            GameHUD.Instance.AddScore(Data.Score);

            Invoke("DestroySelf", 1f);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}