using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        MoveAnim();
    }
    private void MoveAnim()
    {
        if (Input.GetKey(KeyCode.S))
            Anim.SetBool("DOWNMOVE", true);
        else
            Anim.SetBool("DOWNMOVE", false);

        if (Input.GetKey(KeyCode.D))
            Anim.SetBool("RIGHTMOVE", true);
        else
            Anim.SetBool("RIGHTMOVE", false);

        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetBool("LEFTMOVE", true);
            sprite.flipX = true;
        }
        else
        {
            Anim.SetBool("LEFTMOVE", false);
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.W))
            Anim.SetBool("UPMOVE", true);
        else
            Anim.SetBool("UPMOVE", false);
    }


}
