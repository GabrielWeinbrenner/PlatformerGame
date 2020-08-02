using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;


    Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newEnemyVelocity;
        if (IsFacingRight())
        {
            newEnemyVelocity = new Vector2(moveSpeed, myRigidBody.velocity.y); // Creates a vector
        }
        else
        {
            newEnemyVelocity = new Vector2(-moveSpeed, myRigidBody.velocity.y); // Creates a vector

        }
        myRigidBody.velocity = newEnemyVelocity;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);

    }
    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
