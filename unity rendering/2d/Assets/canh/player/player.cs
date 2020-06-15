using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class player : MonoBehaviour
{
    bool isalive = true;
    Rigidbody2D myrigdbody2d;
    Animator myanimator;
    CapsuleCollider2D mybodyCollider2D;
    BoxCollider2D myfeet;
    float scalegravityatstart;
    [SerializeField] float runspeed = 5f;
    [SerializeField] float jumpspeed = 8f;
    [SerializeField] float climbspeed = 5f;
    [SerializeField] Vector2 deathkick=new Vector2(1f,1f);
    // Start is called before the first frame update
    void Start()
    {
        myrigdbody2d = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        mybodyCollider2D = GetComponent<CapsuleCollider2D>();
        myfeet = GetComponent<BoxCollider2D>();
        scalegravityatstart = myrigdbody2d.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isalive)
        {
            return;
        }
        Run();
        climbing();
        jump();
        flipsprite();
        die();
        
        
    }
    void Run()
    {
        float controlthrow = CrossPlatformInputManager.GetAxis("horizontal");
        Vector2 playervelocity = new Vector2(controlthrow*runspeed, myrigdbody2d.velocity.y);
        myrigdbody2d.velocity = playervelocity;
        print(playervelocity);
        bool playerhashorizontalspeed = Mathf.Abs(myrigdbody2d.velocity.x) > Mathf.Epsilon;
        myanimator.SetBool("running", playerhashorizontalspeed);

    }
    void climbing()
    {
        if(!myfeet.IsTouchingLayers(LayerMask.GetMask("ladder")))
        {
            myanimator.SetBool("climbing", false);
            myrigdbody2d.gravityScale = scalegravityatstart;
            return;
        }
        float controlthrow = Input.GetAxis("Vertical");
        Vector2 climbvelocity = new Vector2(myrigdbody2d.velocity.x, controlthrow * climbspeed);
        myrigdbody2d.velocity = climbvelocity;
        myrigdbody2d.gravityScale = 0f;
        bool playerhasverticalspeed = Mathf.Abs(myrigdbody2d.velocity.y) > Mathf.Epsilon;
        myanimator.SetBool("climbing", playerhasverticalspeed);
    }
    void jump()
    {
        if(!myfeet.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpvelocitytoadd = new Vector2(0f,jumpspeed);
            myrigdbody2d.velocity += jumpvelocitytoadd;
        }
    }
    void die()
    {
        if(mybodyCollider2D.IsTouchingLayers(LayerMask.GetMask("enemy","hazradous")))
        {
            print("chet me may di");
            isalive = false;
            myanimator.SetTrigger("die");
            GetComponent<Rigidbody2D>().velocity = deathkick;
            FindObjectOfType<gamesession>().processplayerdeath();
        }
    }
    void flipsprite()
    {
        bool playerhashorizontalspeed = Mathf.Abs(myrigdbody2d.velocity.x) > Mathf.Epsilon;
        if (playerhashorizontalspeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigdbody2d.velocity.x), 1f);
        }
    }
}
