using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        const float moveSpeedX = 5.0f;
        const float moveSpeedY = 8.0f;
        const float moveSpeedZ = 5.0f;

        if (Input.GetKey(KeyCode.D))
        {
            v.x = moveSpeedX;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            v.x = -moveSpeedX;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            v.z = moveSpeedZ;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v.z = -moveSpeedZ;
        }
        else
        {
            v.z = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            v.y = moveSpeedY;
        }
        else
        {
            v.y = 0;
        }

        rb.velocity = v;
    }
}
