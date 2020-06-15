using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    [SerializeField] float movespeed = 3f;
    Rigidbody2D myrigidbody2D;
    bool isfacingright;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isfacingright())
        {
            myrigidbody2D.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            myrigidbody2D.velocity = new Vector2(-movespeed, 0f);
        }


    }
    bool Isfacingright()
    {
        return transform.localScale.x > 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myrigidbody2D.velocity.x)), 1f);

    }
}
