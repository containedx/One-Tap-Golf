using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    Vector2 initialPosition;

    bool throwed = false;

    public void ThrowBall(Vector2 v)
    {
        if (!throwed) // to throw just once per level
        {
            rb.AddForce(v);
            throwed = true;
        }
    }

    public void SetInitailPosition()
    {
        transform.position = initialPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        throwed = false;
    }
}
