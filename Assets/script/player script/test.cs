using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platfrom_Left, moving_Platfrom_Right, is_Breakable, is_Spike, is_Platfrom;
    private Animator anim;

    void Awake() {
        if (is_Breakable)
            anim = GetComponent<Animator>();
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y) {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate() {
        Invoke("DeactivateGameObject", 0.5f);
    }

    void DeactivateGameObject() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            if (is_Spike) {
                target.transform.position = new Vector2(1000f, 1000f);
                GameManager2.instance.GameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            if (is_Breakable) {
                anim.Play("Break");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target) {
        if (target.gameObject.tag == "Player") {
            if (moving_Platfrom_Left) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }

            if (moving_Platfrom_Right) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
