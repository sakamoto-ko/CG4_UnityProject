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

        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeedX;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeedX;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            v.y = moveSpeedY;
        }

        rb.velocity = v;
    }
}
