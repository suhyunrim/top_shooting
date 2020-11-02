using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public abstract class CollisionObject : MonoBehaviour
{
    public Vector2 MovementVector;

    protected virtual void Update()
    {
        transform.Translate(MovementVector);
    }

    protected abstract void OnCollisionEnter(Collision collision);
}