using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float movespeed = 2f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(movespeed, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-movespeed, myBody.velocity.y);
        }
    }

    public void platformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
