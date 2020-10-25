using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CollisionObject
{
    public GameObject BulletPrefab;
    public int BulletTerm = 20;
    public float MovementSpeed = 0.1f;

    private int bulletTermCount = 0;
    private float defaultY;

    private void Start()
    {
        defaultY = transform.position.y;
    }

    protected override void Update()
    {
        base.Update();

        MovementVector = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var diff = worldPosition.x - transform.position.x;
            if (Mathf.Abs(diff) < 0.05f)
            {
                transform.position = new Vector3(worldPosition.x, defaultY, 0);
            }
            else
            {
                MovementVector = new Vector2(diff / 10f, 0);
            }
        }

        if (bulletTermCount++ >= BulletTerm)
        {
            Fire();
            bulletTermCount = 0;
        }
    }

    private void Fire()
    {
        var bulletObject = Instantiate(BulletPrefab);
        bulletObject.transform.position = transform.position;
        bulletObject.transform.Translate(new Vector3(0, 0.5f));
    }

    protected override void OnCollisionEnter(Collision collision)
    {
    }
}