using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformscript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    void Awake()
    {
        if (is_Breakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
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
                    playerIndicator.UseShield(); // Use the shield and prevent player from dying
                    Debug.Log("Shield used! Player is safe.");
                }
                else
                {
                    target.transform.position = new Vector2(1000f, 1000f);
                    SoundManager.instance.GameOverSound();
                    GameManager.instance.RestartGame();
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (is_Breakable)
            {
                SoundManager.instance.LandSound();
                anim.SetTrigger("break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<playermovement>().platformMove(-1f);
            }

            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<playermovement>().platformMove(1f);
            }
        }
    }
}
