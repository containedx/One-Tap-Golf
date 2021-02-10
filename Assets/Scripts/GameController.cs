using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Ball ball;

    public Trajectory trajectory;

    [SerializeField]
    float force;

    Vector2 start;
    Vector2 end;
    Vector2 direction;
    Vector2 v;
    float distance;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //if LMB clicked
        {
            InstantiatePosition();
        }
        if (Input.GetButton("Fire1"))
        {
            Pointing();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Throw();
        }
    }


    void InstantiatePosition()
    {
        start = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Pointing()
    {
        end = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(start, end);
        direction = (start - end).normalized;
        v = direction * distance * force;

        IncreaseForce();
        trajectory.Active(true);
        trajectory.CalculatePositions(ball, v);
    }

    void Throw()
    {
        ball.ThrowBall(v);
        trajectory.Active(false);
        force = 5; //back to initial force
    }

    void IncreaseForce()
    {
        force += 0.001f;
    }
}
