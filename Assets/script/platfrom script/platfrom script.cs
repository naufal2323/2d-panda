using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platfromscript : MonoBehaviour{

    public float move_speed = 2f;
    public float bound_Y = 6f;

    public bool moving_Platfrom_Left, moving_Platfrom_Right, is_Breakable, is_Spike, is_Platfrom;

    private Animator anim;

    void Awake(){
        if(is_Breakable)
            anim = GetComponent<Animator>();
    }

    void Update(){
        Move();
    }

     void Move(){
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }
}
