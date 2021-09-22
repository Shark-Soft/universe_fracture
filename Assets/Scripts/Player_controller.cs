using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float speed, jumpHeight;
    float velx, vely;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundcheckRadius;
    public LayerMask whatisGround;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisGround);

        if(isGrounded){
            anim.SetBool("jump", false);
        }
        else{
            anim.SetBool("jump", true);
        }

        Flipcharacter();
        attack();

    }

    private void FixedUpdate() {
        movimiento();
        jump();
    }

    public void attack(){
        if(Input.GetButton("Fire1")){
            anim.SetBool("ataque", true);
        }
        else{
            anim.SetBool("ataque", false);
        }
    }

    public void movimiento(){
        velx = Input.GetAxisRaw("Horizontal");
        vely = rb.velocity.y;

        rb.velocity = new Vector2(velx * speed , vely);

        if(rb.velocity.x != 0){
            anim.SetBool("run", true);
        }
        else{
            anim.SetBool("run", false);
        }
    }

    public void jump(){
        if(Input.GetButton("Jump") && isGrounded){
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    public void Flipcharacter(){
        if(rb.velocity.x > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rb.velocity.x < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
