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

    public EndOfScreen endOfScreen;
    public BehindHole behindHole;
    public GameObject gameOverScreen;

    [SerializeField]
    float force;

    Vector2 start;
    Vector2 end;
    Vector2 direction;
    Vector2 v;
    float distance;

    bool pointing=false;

    public Text scoreText;
    int score=0;

    void Update()
    {
        HandleThrowing();
        HandleEndOfScreen();
        HandleGameOver();
    }

    void HandleThrowing()
    {
        if (Input.GetButtonDown("Fire1")) //if LMB clicked
        {
            InstantiatePosition();
            pointing = true;
        }
        if (pointing)
        {
            Pointing();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Throw();
        }
    }

    void HandleEndOfScreen()
    {
        if (endOfScreen.entered)
        {
            Throw();
        }
    }

    void HandleGameOver()
    {
        if(behindHole.entered)
        {
            gameOverScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GameController (empty object) is located in the hole
        //and has attached collider at the bottom of the hole
        if (collision.transform.name == "Ball")
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
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
        pointing = false;
        ball.ThrowBall(v);
        trajectory.Active(false);
        force = 5; //back to initial force
    }

    void IncreaseForce()
    {
        force += (0.001f * (score+1));
    }
}
