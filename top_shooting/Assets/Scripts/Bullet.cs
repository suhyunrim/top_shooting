using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(0, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }
    }
}