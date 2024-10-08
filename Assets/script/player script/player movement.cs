using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 12f;  // Tingkatkan kecepatan gerakan horizontal
    public float swipeThreshold = 0.05f; // Turunkan threshold untuk lebih responsif
    public float smoothFactor = 0.2f;  // Percepat interpolasi untuk membuat gerakan lebih halus

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isDragging = false;
    private Vector2 targetVelocity;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Movechar()
    {
        // Menggunakan Time.deltaTime untuk menjaga konsistensi di semua platform
        myBody.position += new Vector2(targetVelocity.x, targetVelocity.y) * Time.deltaTime;
    }

    private void Update()
    {
        HandleTouch();
    }

    void FixedUpdate()
    {
        Movechar();
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

                        // Tidak perlu membagi dengan resolusi layar, cukup gunakan vektor pergerakan langsung
                        swipeDirection.Normalize();  // Normalisasi untuk mendapatkan arah swipe

                        // Cek apakah swipe lebih panjang dari threshold untuk mendeteksi gerakan horizontal
                        if (Mathf.Abs(swipeDirection.x) > swipeThreshold)
                        {
                            // Gerakan horizontal (swipe kanan atau kiri)
                            if (swipeDirection.x > 0)
                            {
                                // Gerak kanan
                                targetVelocity = new Vector2(moveSpeed, 0);
                            }
                            else
                            {
                                // Gerak kiri
                                targetVelocity = new Vector2(-moveSpeed, 0);
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
        myBody.position += new Vector2(targetVelocity.x, targetVelocity.y) * Time.deltaTime;
    }

    public void PlatformMove(float x)
    {
        targetVelocity = new Vector2(x, myBody.velocity.y);
    }
}
