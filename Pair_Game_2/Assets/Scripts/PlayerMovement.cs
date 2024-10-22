using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    //public LayerMask platforms;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying) Move();
        else rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void Move()
    {
        //move sideways
        float horiz = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector3(horiz, rb.velocity.y, 0);
        
        //jump if on the ground
        if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded()) rb.AddForce(new Vector3(0, jumpHeight, 0));
    }
    
    //checks if currently on the ground
    bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1<<6); //ground layer is currently hard-coded to 6
    }

    public void Death()
    {
        print("oopsie i died");
    }
}
