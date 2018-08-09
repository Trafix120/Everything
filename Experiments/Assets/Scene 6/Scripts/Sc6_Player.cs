using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc6_Player : MonoBehaviour {
    // Player Simple Movements
    public float speed = 1f;        // Holds the speed of the players info

    private bool touchingGround;    // If the player is touching the ground it is true
    private Vector3 horInput;       // Holds the horizontal input info

    // Jumps
    public float jumpSpeed;         // The speed of the jump
    private bool transJump;         // Transfers normal Update to FixedUpdate jump info
    private bool canJump = true;    // If true the player jumps
    public float jumpProg;          // The progreess the jump has before it reaches the jump max;
    public float jumpMax;           // The jump max
    public float afterFallJumpAccel;// After the jump this is the jump acceleration downwards felt

    // Faster fall
    private bool transFastFall;     // Transfers the bool fastfall from Update() to FixedUpdate()
    public float fastFallSpeed;     // The speed at which the player fast falls

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horInput = Vector3.right * Input.GetAxisRaw("Horizontal");
        // Jumps
        if (Input.GetKey(KeyCode.W) && canJump && jumpProg < jumpMax)
        {
            transJump = true;
            jumpProg += Time.deltaTime;
        }
        // Does a fastfall
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            transFastFall = true;
        }
        // Stops jumping
        else
        {

            transJump = false;
        }
        // Causes the backup check to go false
        if (Input.GetKeyUp(KeyCode.W))
        {
            canJump = false;
        }
        // causes the backup jump check to go true
        if (touchingGround)
        {
            canJump = true;
            jumpProg = 0;
        }
    }

    private void FixedUpdate()
    {

        transform.position += horInput * speed / 10;
        if (transJump)
        {
            transform.position += Vector3.up * jumpSpeed * Time.deltaTime * GetComponent<Rigidbody2D>().gravityScale;
        }
        if (transFastFall && !touchingGround)
        {
            Debug.Log("Going down faster");
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * fastFallSpeed, ForceMode2D.Impulse);
            transFastFall = false;
        }
        if (!transJump && !touchingGround)
        {
            Debug.Log("going down faster");
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * afterFallJumpAccel, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = true;
            Debug.Log("ground touched");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = false;

            Debug.Log("leaving ground");
        }
    }
}
