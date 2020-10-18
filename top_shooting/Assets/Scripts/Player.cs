using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;

    private int bulletTerm = 0;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.1f, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0.1f, 0);
        }

        if (bulletTerm++ >= 20)
        {
            var bulletObject = Instantiate(BulletPrefab);
            bulletObject.transform.position = transform.position;

            bulletTerm = 0;
        }
    }
}