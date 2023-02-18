using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float veloY,veloX;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        Move();
    }
    private void Move()
    {
        veloX = Input.GetAxis("Horizontal") * GameManager.Instance.PlayerSpeed;
        veloY = Input.GetAxis("Vertical") * GameManager.Instance.PlayerSpeed;
        rb.velocity = new Vector2(veloX, veloY);
    }
}
