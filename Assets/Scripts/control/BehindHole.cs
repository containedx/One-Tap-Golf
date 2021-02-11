﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindHole : MonoBehaviour
{
    public bool entered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.name == "Ball")
        {
            entered = true;
        }
    }
}