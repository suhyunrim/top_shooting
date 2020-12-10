using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public abstract class CollisionObject : MonoBehaviour
{
    public Vector2 MovementVector;

    protected virtual void Update()
    {
        transform.Translate(MovementVector);
    }

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}