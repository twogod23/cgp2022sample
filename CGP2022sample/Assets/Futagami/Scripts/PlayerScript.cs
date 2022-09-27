using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float jump = 600f;
    private float walk = 200f;
    public float jumpcount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプの設定
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpcount == 0)
            {
                rb2d.AddForce(Vector2.up * jump);
                jumpcount = 1;
            }else if(jumpcount == 1)
            {
                //かかる力を一度ゼロにして自然なジャンプをする
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up * jump);
                jumpcount = 2;
            }
            else
            {

            }
        }

        //横移動の設定
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            rb2d.AddForce(Vector2.left * walk);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            rb2d.AddForce(Vector2.right * walk);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("BlockSurface"))
        {
            jumpcount = 0;
        }
    }
}
