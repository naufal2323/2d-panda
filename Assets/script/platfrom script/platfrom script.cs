using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;

    public bool movingPlatformLeft, movingPlatformRight, isBreakable, isSpike, isPlatform;

    private Animator anim;
    private Collider2D spikeCollider;

    void Awake()
    {
        if (isBreakable)
        {
            anim = GetComponent<Animator>();
        }

        if (isSpike)
        {
            spikeCollider = GetComponent<Collider2D>();
        }
    }

    void Update()
    {
        if (GameManager2.instance != null && GameManager2.instance.isGameOver)
        {
            return; // Stop execution if the game is over
        }
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.5f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            Indicator playerIndicator = target.GetComponent<Indicator>();

            if (isSpike)
            {
                if (playerIndicator != null && playerIndicator.hasShield)
                {
                    playerIndicator.UseShield(); // Use the shield and prevent player from dying
                    Debug.Log("Shield used! Player is safe.");
                    spikeCollider.isTrigger = false; // Disable trigger to allow player to stand on spike
                }
                else
                {
                    target.transform.position = new Vector2(1000f, 1000f); // Simulate player "death"
                    SoundManager.instance.GameOverSound();
                    GameManager2.instance.GameOver();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag("Player") && isSpike)
        {
            spikeCollider.isTrigger = true; // Re-enable trigger when player leaves spike platform
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Indicator playerIndicator = target.gameObject.GetComponent<Indicator>();

            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                anim.SetTrigger("break");
            }

            if (isPlatform)
            {
                SoundManager.instance.LandSound();
            }

            if (isSpike && playerIndicator != null && playerIndicator.hasShield)
            {
                // Prevent any further action, allowing player to stay on spiked platform
                return;
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerMovement = target.gameObject.GetComponent<PlayerMovement>();

            if (movingPlatformLeft)
            {
                playerMovement.PlatformMove(-1f);
            }

            if (movingPlatformRight)
            {
                playerMovement.PlatformMove(1f);
            }

            Indicator playerIndicator = target.gameObject.GetComponent<Indicator>();
            if (isSpike && playerIndicator != null && playerIndicator.hasShield)
            {
                // Prevent any further action, allowing player to stay on spiked platform
                return;
            }
        }
    }
}
