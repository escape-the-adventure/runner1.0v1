using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

    public bool grounded = false;

    Transform tr;

    void Start()
    {
        tr = transform;
    }

    public bool IsGrounded()
    {
        if (Physics.Raycast(tr.position, -tr.up, 0.2f))
        {

            grounded = true;
        }
        else
        {
            grounded = false;
        }

        return grounded;
    }
}
