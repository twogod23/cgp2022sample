using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float jump = 600f;
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
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }
}
