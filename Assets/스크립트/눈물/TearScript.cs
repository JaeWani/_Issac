using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearScript : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] AudioClip TearDelete;

    Vector2 StartPosition;
    Vector2 EndPosition;
    bool t = false;
    private void Start()
    {
        StartPosition = transform.position;
        EndPosition = new Vector2(StartPosition.x+GameManager.Instance.TearRange, StartPosition.y + GameManager.Instance.TearRange);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (t == false&& transform.position.x >= EndPosition.x) 
            TearEnd();
        if (t == false && transform.position.y >= EndPosition.y)
            TearEnd();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            TearEnd();
        }
    }
    void TearEnd() 
    {
        rb.velocity = new Vector2(0, 0);
        AudioManager.Instance.TearDestroySound(TearDelete);
        anim.SetTrigger("Delete");
        t = true;
    }
    public void TearDestroy()
    {
        Destroy(gameObject);
    }
}
