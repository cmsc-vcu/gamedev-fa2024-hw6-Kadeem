using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    //public LayerMask platforms;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //move sideways
        float horiz = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector3(horiz, rb.velocity.y, 0);

        //boing boing! this currently jumps infinitely haha
        if(Input.GetKeyDown(KeyCode.UpArrow) && Grounded()) rb.AddForce(new Vector3(0, jumpHeight, 0));
    }

    bool Grounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1<<6);
    }
}
