using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 1.5f;
    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Collider2D myCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); // Gets the component rigid body from the player object
	myAnimator = GetComponent<Animator>();
	myCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
	Jump();
	ClimbLadder();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal"); // -1 to +1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y); // Creates a vector
        myRigidBody.velocity = playerVelocity;
	if(myRigidBody.velocity.x != 0){
	    myAnimator.SetBool("Running", true);
	}else{
	    myAnimator.SetBool("Running", false);
	}
        
    }
    private void Jump()
    {
	if(myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))){ 
	    if(Input.GetButtonDown("Jump"))
	    {
	        Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
	        myRigidBody.velocity += jumpVelocityToAdd;
	    }
	}
	

    }
    private void ClimbLadder()
    {
	if(myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder"))){
	    myAnimator.SetBool("Climbing", true);
	    float controlFlow = Input.GetAxis("Vertical");
	    Vector2 playerVelocity = new Vector2(myRigidBody.velocity.x, controlFlow * climbSpeed);
            myRigidBody.velocity = playerVelocity;
	    

	}else{
	    myAnimator.SetBool("Climbing", false);
	}

    }
    private void FlipSprite()
    {
        // if player moves horizontally
        bool playerHasHorizontalSpeed = myRigidBody.velocity.x < Mathf.Epsilon;
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

}
