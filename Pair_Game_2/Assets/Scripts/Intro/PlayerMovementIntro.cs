using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIntro : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    Animator anim;
    //public LayerMask platforms;
    Rigidbody2D rb;
    Vector3 spawnpoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnpoint = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if(!DialogueManager.GetInstance().dialogueIsPlaying && !PauseManager.GetInstance().isPaused) Move();
        else rb.velocity = new Vector3(0, rb.velocity.y, 0);
    }

    void Move()
    {
        //move sideways
        float horiz = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector3(horiz, rb.velocity.y, 0);
        
        //jump if on the ground
        if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded()) rb.AddForce(new Vector3(0, jumpHeight, 0));
        Animate();
    }

    void Animate()
    {
        anim.SetBool("grounded", Grounded());
        anim.SetBool("walking", Input.GetAxis("Horizontal") > 0.1f || Input.GetAxis("Horizontal") < -0.1f);

    }
    
    //checks if currently on the ground
    bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f, 1<<6); //ground layer is currently hard-coded to 6
    }

    public void setSpawn(float x, float y, float z)
    {
        spawnpoint = new Vector3(x, y, z);
    }

    public void setSpawn(Vector3 newSpawn)
    {
        spawnpoint = newSpawn;
    }
}
