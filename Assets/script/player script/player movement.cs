using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 2f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isDragging = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleTouch();
    }

    void HandleTouch()
    {
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        endTouchPosition = touch.position;
                        Vector2 swipeDirection = endTouchPosition - startTouchPosition;

                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            // Horizontal swipe
                            if (swipeDirection.x > 0)
                            {
                                // Right swipe
                                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
                            }
                            else
                            {
                                // Left swipe
                                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
                            }
                        }
                        startTouchPosition = endTouchPosition; // Update start position for continuous swipe
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    myBody.velocity = Vector2.zero; // Stop movement when touch ends
                    break;
            }
        }
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
