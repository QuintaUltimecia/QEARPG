using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandRotation : MonoBehaviour
{
    private bool active = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (transform.childCount != 0 && active == false)
        {
            transform.GetChild(0).transform.Rotate(180f, 0f, 0f);
            active = true;
        }
        else if (transform.childCount == 0)
        {
            active = false;
        }
    }
}
