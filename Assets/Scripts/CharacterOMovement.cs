using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    
    public float moveForce = 10f;
    public float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D myBody;
    private Animator animator;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";

    
    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();

        sr = GetComponent<SpriteRenderer>();

    }
    

// START is called before the first frame update
    void Start()
    {
        



    }

// UPDATE is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();


    }
        

    private void FixedUpdate()
    {
        PlayerJump();
    }

     void PlayerMoveKeyboard() {
        
        movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

     }  

     void AnimatePlayer()
     {
       
       // Heading to the right
       if (movementX > 0) {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
       }
       
       // Heading to the left
       else if (movementX < 0)
       {
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
       }

       else
       {
         animator.SetBool(WALK_ANIMATION, false);
       }

     }

     void PlayerJump() {

        if(Input.GetButtonDown("Jump") && isGrounded) {
                isGrounded = false;
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

     }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }
    }



} //class
