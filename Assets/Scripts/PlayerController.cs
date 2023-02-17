using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityCD = 1.5f;
    public float gravityCDCurrent = 0.0f;
    public bool gravityReady;



    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool top;
    private Rigidbody2D rb;
    private bool virado = false;
    private float viradocheck = 1;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) {
            Flip();
        }
        if(virado == true && moveInput != 0 ){
            facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && gravityReady){
            rb.gravityScale *= -1;
            jumpForce *= -1;
            gravityCDCurrent = 0.0f;
            viradocheck *= -1;
            Rotation();
        }
        if(viradocheck>0){
            virado = false;
        }
        if(viradocheck<0){
            virado = true;
            }

         if(gravityCDCurrent >= gravityCD){
            gravityReady = true;
        } 
        else{
            gravityCDCurrent = gravityCDCurrent + Time.deltaTime;
            gravityReady = false;
        }


        if (isGrounded == true) {
            extraJump = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJump > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        } else if (Input.GetKeyDown(KeyCode.W) && extraJump == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }


    }

    void Flip() {
        /*facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        Debug.Log("Virou");*/
        
        if(virado == true){
            facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        }
        if(virado == false){
            Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
        }

    }
    public void Rotation(){
        if(top == false){
            transform.eulerAngles = new Vector3 (0, 0, 180f);
        } else {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }
    public void MoreJump()
    {
        Debug.Log("Double Jump");
        extraJumpValue++;
        return;
    }
}
