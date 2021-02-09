using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject point;
    void Update()
    {
        // Dont Show Points If LMB not clicked
        if(Input.GetButtonUp("Fire1"))
        {
            Destroy(point);
        }
    }
}
