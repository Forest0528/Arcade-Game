using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerwall : MonoBehaviour
{

    private Rigidbody2D rb;


    [SerializeField] private float speed;
    private float harSpeed;
    [SerializeField] private float imp;
    public float JumpForse;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGround;
    private bool facingRight = true;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
    }
     
    private void FixedUpdate()
    {
        transform.Translate(harSpeed, 0, 0);
    }


   
    public void OnRight()
    {
        harSpeed = speed;
        GetComponent<SpriteRenderer>().flipX = false;
        anim.SetBool("isRunning", true);
    }

    public void OnLeft()
    {
        harSpeed = -speed;
        GetComponent<SpriteRenderer>().flipX = true;
        anim.SetBool("isRunning", true);
    }

    public void OnJump()
    {
        if (isGround)
        {
            //rb.AddForce(transform.up * imp * Time.deltaTime, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(0, imp), ForceMode2D.Impulse);
            anim.SetTrigger("takeOf");
        }
    }

    public void Stop()
    {
        harSpeed = 0;
        anim.SetBool("isRunning", false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGround = true;
        anim.SetBool("isJumping", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGround = false;
        anim.SetBool("isJumping", true);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
