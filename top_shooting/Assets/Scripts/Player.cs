using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int BulletTerm = 20;
    public float MovementSpeed = 0.1f;

    private int bulletTermCount = 0;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + new Vector3(-MovementSpeed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(MovementSpeed, 0);
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
    }
}