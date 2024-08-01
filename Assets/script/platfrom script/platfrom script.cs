using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformscript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;
    private Collider2D spikeCollider;
    private Animator platformAnimator;

    void Awake()
    {
        if (is_Breakable)
        {
            anim = GetComponent<Animator>();
        }

        if (is_Spike)
        {
            spikeCollider = GetComponent<Collider2D>();
        }

        platformAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager2.instance != null && GameManager2.instance.isGameOver)
        {
            if (platformAnimator != null)
            {
                platformAnimator.speed = 0;
            }
            return;
        }

        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
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

            if (is_Spike)
            {
                if (playerIndicator != null && playerIndicator.hasShield)
                {
                    playerIndicator.UseShield();
                    Debug.Log("Shield used! Player is safe.");
                    spikeCollider.isTrigger = false;
                }
                else
                {
                    target.transform.position = new Vector2(1000f, 1000f);
                    SoundManager.instance.GameOverSound();
                    if (GameManager2.instance != null)
                    {
                        GameManager2.instance.GameOver();
                    }
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag("Player") && is_Spike)
        {
            spikeCollider.isTrigger = true;
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Indicator playerIndicator = target.gameObject.GetComponent<Indicator>();

            if (is_Breakable)
            {
                SoundManager.instance.LandSound();
                anim.SetTrigger("break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }

            if (is_Spike && playerIndicator != null && playerIndicator.hasShield)
            {
                return;
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            Indicator playerIndicator = target.gameObject.GetComponent<Indicator>();

            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<playermovement>().platformMove(-1f);
            }

            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }

            if (is_Spike && playerIndicator != null && playerIndicator.hasShield)
            {
                return;
            }
        }
    }
}
