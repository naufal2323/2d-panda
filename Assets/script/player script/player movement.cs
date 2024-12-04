using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float moveSpeed = 10f;
    public float swipeThreshold = 0.05f;
    public float smoothFactor = 0.2f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isDragging = false;
    private Vector2 targetVelocity;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleTouch();
    }

    void FixedUpdate()
    {
        if (GameManager2.instance.isGameOver)
        {
            // Pastikan pemain berhenti sepenuhnya saat game over
            myBody.velocity = Vector2.zero;
            return;
        }

        // Smooth movement menggunakan Lerp untuk horizontal direction
        Vector2 smoothedVelocity = Vector2.Lerp(myBody.velocity, targetVelocity, smoothFactor);
        myBody.velocity = new Vector2(smoothedVelocity.x, myBody.velocity.y);
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
                        if (Mathf.Abs(swipeDirection.x) > swipeThreshold)
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

                            // Perbarui startTouchPosition untuk mendukung swipe berkelanjutan
                            startTouchPosition = endTouchPosition;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    // Set targetVelocity ke 0 untuk berhenti saat lepas hold
                    targetVelocity = Vector2.zero;
                    break;
            }
        }
    }

    public void PlatformMove(float x)
    {
        targetVelocity = new Vector2(x, myBody.velocity.y);
    }

    // Tambahan fungsi untuk mengatur ulang pemain saat respawn
    public void RespawnPlayer(Vector2 respawnPosition)
    {
        myBody.velocity = Vector2.zero; // Hentikan kecepatan
        transform.position = respawnPosition; // Set posisi pemain
        myBody.simulated = true; // Aktifkan physics jika sebelumnya dimatikan
        GameManager2.instance.isGameOver = false; // Set state game agar aktif kembali
    }

    // Fungsi untuk menghentikan pemain saat game over
    public void StopPlayer()
    {
        myBody.velocity = Vector2.zero; // Hentikan gerakan
        myBody.simulated = false; // Nonaktifkan physics agar tidak ada interaksi
    }
}
