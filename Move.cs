using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;
    public int extraJumpsValue;

    void Start() {
        rb = GetComponent<Rigidbody2D>();    
        extraJumps = extraJumpsValue;
    }

    void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0){
            flip();
        }else if(facingRight == true && moveInput < 0){
            flip();
        }
    }

    private void Update() {

        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
        if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
    }

    void flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
