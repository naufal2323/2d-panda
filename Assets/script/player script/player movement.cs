using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 8f;  // Tingkatkan kecepatan gerakan horizontal
    public float swipeThreshold = 30f; // Turunkan threshold untuk lebih responsif
    public float smoothFactor = 0.2f;  // Percepat interpolasi untuk membuat gerakan lebih halus
  

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isDragging = false;
    private Vector2 targetVelocity;

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
        if (Input.touchCount > 0)
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

                        // Cek apakah swipe lebih panjang dari threshold untuk mendeteksi gerakan horizontal
                        if (swipeDirection.magnitude > swipeThreshold)
                        {
                            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                            {
                                // Gerakan horizontal (swipe kanan atau kiri)
                                if (swipeDirection.x > 0)
                                {
                                    // Gerak kanan
                                    targetVelocity = new Vector2(moveSpeed, myBody.velocity.y);
                                }
                                else
                                {
                                    // Gerak kiri
                                    targetVelocity = new Vector2(-moveSpeed, myBody.velocity.y);
                                }
                            }

                            // Perbarui startTouchPosition untuk mendukung swipe berkelanjutan
                            startTouchPosition = endTouchPosition;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    targetVelocity = new Vector2(0, myBody.velocity.y); // Berhenti bergerak horizontal saat touch selesai
                    break;
            }
        }

        // Lerp untuk perpindahan yang lebih mulus hanya pada sumbu x
        myBody.velocity = new Vector2(Mathf.Lerp(myBody.velocity.x, targetVelocity.x, smoothFactor), myBody.velocity.y);
    }

    public void PlatformMove(float x)
    {
        targetVelocity = new Vector2(x, myBody.velocity.y);
    }
}
