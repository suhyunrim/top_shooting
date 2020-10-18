using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int BulletTerm = 20;

    private int bulletTermCount = 0;

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

        if (bulletTermCount++ >= BulletTerm)
        {
            var bulletObject = Instantiate(BulletPrefab);
            bulletObject.transform.position = transform.position;

            bulletTermCount = 0;
        }
    }
}