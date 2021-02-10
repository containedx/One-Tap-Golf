using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Ball ball;
    public Hole hole;

    public Trajectory trajectory;

    [SerializeField]
    float force;

    Vector2 start;
    Vector2 end;
    Vector2 direction;
    Vector2 v;
    float distance;

    public Text scoreText;
    int score=0;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameController (empty object) is located in the hole
        //and has attached collider at the bottom of the hole
        score += 1;
        scoreText.text = score.ToString();
        ball.SetInitailPosition();
        hole.SetRandomPosition();
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
        force += (0.001f * (score+1));
    }
}
