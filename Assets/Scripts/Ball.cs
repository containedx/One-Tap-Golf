using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    Vector2 InitialPosition;

    public void ThrowBall(Vector2 v)
    {
        rb.AddForce(v);
    }

    public void SetInitailPosition()
    {
        transform.position = InitialPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }
}
