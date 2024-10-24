using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    //public LayerMask platforms;
    Rigidbody2D rb;
    Vector3 spawnpoint;
    public CameraMovement cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }
    
    //checks if currently on the ground
    bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1<<6); //ground layer is currently hard-coded to 6
    }

    public void setSpawn(float x, float y, float z)
    {
        spawnpoint = new Vector3(x, y, z);
    }

    public void setSpawn(Vector3 newSpawn)
    {
        spawnpoint = newSpawn;
    }

    //for this to work, only one death can exist for ease 
    public void Death()
    {
        cam.dying = true;
        print("oopsie i died");
        transform.position = spawnpoint;
    }
}
