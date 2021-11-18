using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class Player_controller : MonoBehaviour
{   health playerHealth;
public int damageAmount;
public float damageTime;
float currentDamageTime;

public float speed, jumpHeight;
public int playerNumber;
float velx, vely;
Rigidbody2D rb;
public Transform groundcheck;
public bool isGrounded;
public float groundcheckRadius;
public LayerMask whatisGround;
Animator anim;
// Global Player
string fireKey ;
string jumpKey ;
string horizontalKey ;

public float minx;
public float maxx;
        AnimationClip clip;

private AudioSource sataque;

    AnimationEvent evt;
// Start is called before the first frame update
void Start()
{   
    evt = new AnimationEvent();
    evt.time = 0.45f;
    evt.functionName = "AtackOff";

     Debug.Log("Awake:" + SceneManager.GetActiveScene().name);

    if(playerNumber==1){
        playerHealth = GameObject.Find("Player2").GetComponent<health>();
    }else{
        playerHealth = GameObject.Find("Player1").GetComponent<health>();
    }
    
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    switch (playerNumber)
        {
            case 1:
                fireKey = "FirePlayer1";
                jumpKey="JumpP1";
                horizontalKey="HorizontalP1";
                break;
            case 2:
                fireKey = "FirePlayer2";
                jumpKey="JumpP2";
                horizontalKey="HorizontalP2";
                break;
                default:
                fireKey = "FirePlayer1";
                jumpKey="JumpP1";
                horizontalKey="HorizontalP1";

                break;

        }

        sataque = GetComponent<AudioSource>();
}


// Update is called once per frame
void Update()
{
    isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, whatisGround);
    if(SceneManager.GetActiveScene().name != "GameOver")
    if(playerHealth.percent <= 0){
        GameObject.DontDestroyOnLoad(this.gameObject);
        FindObjectOfType<GameManager>().GameOver();

    }

    if(isGrounded){
        anim.SetBool("jump", false);
    }
    else{
        anim.SetBool("jump", true);
    }

    Flipcharacter();

}

private void FixedUpdate() {
    movimiento();
    attack();
    jump();
}

public void attack(){
     if(Input.GetButton(fireKey)){
        anim.SetBool("ataque", true);
        sataque.Play();
        clip = anim.GetCurrentAnimatorClipInfo(0)[0].clip;

        clip.AddEvent(evt);
    }
    // else{
    //     // if(anim.getBool("ataque")){
    //         if(!anim.GetCurrentAnimatorStateInfo(0).IsName("atacar") ){

    //         }
    //     // }
    // }

}
public void AtackOff(){
        anim.SetBool("ataque", false);
}


public void movimiento(){
    velx = Input.GetAxisRaw(horizontalKey);
    vely = rb.velocity.y;


    rb.velocity = new Vector2(velx * speed , vely);

    transform.position = new Vector3(Mathf.Clamp(transform.position.x,minx,maxx) , transform.position.y, transform.position.z);

    if(rb.velocity.x != 0){
        anim.SetBool("run", true);
    }
    else{
        anim.SetBool("run", false);
    }
}

public void jump(){
    if(Input.GetButton(jumpKey) && isGrounded){
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

 public void on(Collider2D other)  {
    print("touch");

}
 private void OnCollisionStay2D(Collision2D other) {

    if(other.gameObject.tag == "Player" ){
        currentDamageTime+=Time.deltaTime;
       
        if(currentDamageTime >damageTime && anim.GetBool("ataque")){
            playerHealth.percent+=damageAmount;
            currentDamageTime=0.0f;
        }


    }else{
             Debug.Log("touch "+ other.gameObject.name);
    if(other.gameObject.name =="portal"){
    }

    }
 }
}
