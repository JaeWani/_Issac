using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator Anim;
    [Header ("赣府 规氢")]
    [SerializeField] public HeadDirection CurrentDirection;
    [SerializeField] Sprite L, R, U, D;
    [Header ("传拱 荤款靛")]
    [SerializeField] AudioClip[] TearFire;
    [Header("传拱 橇府崎")]
    [SerializeField] GameObject Tear;
    public enum HeadDirection 
    { 
    Left,
    Right,
    Up,
    Down
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        ShootAnim();
        SetDirection();
    }
    void ShootAnim() 
    {
        if (Input.GetKey(KeyCode.RightArrow))
            Anim.SetBool("RIGHTATTACK", true);
        else
            Anim.SetBool("RIGHTATTACK", false);

        if (Input.GetKey(KeyCode.UpArrow))
            Anim.SetBool("UPATTACK", true);
        else
            Anim.SetBool("UPATTACK", false);

        if (Input.GetKey(KeyCode.DownArrow))
            Anim.SetBool("DOWNATTACK", true);
        else
            Anim.SetBool("DOWNATTACK", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Anim.SetBool("LEFTATTACK", true);
        }
        else
        {
            Anim.SetBool("LEFTATTACK", false);
            spriteRenderer.flipX = false;
        }
    }

    void SetDirection() 
    {
        if (Input.GetKey(KeyCode.A))
        {
            CurrentDirection = HeadDirection.Left;
            SetSprite();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CurrentDirection = HeadDirection.Right;
            SetSprite();
        }
        ////////////////////////////////////////////////
        if (Input.GetKey(KeyCode.S))
        {
            CurrentDirection = HeadDirection.Down;
            SetSprite();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            CurrentDirection = HeadDirection.Up;
            SetSprite();
        }
    }
    void SetSprite() 
    {
        if (CurrentDirection == HeadDirection.Left) spriteRenderer.sprite = L;
        if (CurrentDirection == HeadDirection.Right) spriteRenderer.sprite = R;
        if (CurrentDirection == HeadDirection.Down) spriteRenderer.sprite = D;
        if (CurrentDirection == HeadDirection.Up) spriteRenderer.sprite = U;
    }
    void Shoot(float veloX,float veloY,Vector2 vector) 
    {
        int rand = Random.Range(0,2);
        AudioManager.Instance.TearFireSound(TearFire[rand]);
        var tear = Instantiate(Tear, vector, Quaternion.identity);
        Rigidbody2D rb = tear.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(veloX, veloY);
    }
    public void LeftShoot() 
    {
        Shoot(-GameManager.Instance.ShootSpeed, 0,transform.position);
    }
    public void RightShoot() 
    {
        Shoot(GameManager.Instance.ShootSpeed, 0, transform.position);
    }
    public void UpShoot() 
    {
        Shoot(0, GameManager.Instance.ShootSpeed, transform.position);
    }
    public void DownShoot()
    {
        Shoot(0, -GameManager.Instance.ShootSpeed,new Vector2(transform.position.x, transform.position.y - 0.2f));
    }
}
