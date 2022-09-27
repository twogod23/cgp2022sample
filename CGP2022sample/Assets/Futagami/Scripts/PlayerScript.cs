using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float jump = 600f;
    public float jumpcount;

    private float blockMoveBefore;
    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpcount = 0;
        blockMoveBefore = 0;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプの設定
        if(Input.GetKeyDown(KeyCode.Space))
        {
            move = true;
            
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
            move = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
            move = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("BlockSurface"))
        {
            jumpcount = 0;
        }

        if (other.gameObject.CompareTag("BlockSurface"))
        {
            if (!Input.GetKeyDown(KeyCode.Space) || !Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow))
            {
                if (move == true)
                {
                    blockMoveBefore = other.gameObject.transform.parent.position.x;
                    move = false;
                }
                else
                {
                    float blockMove = other.gameObject.transform.parent.position.x - blockMoveBefore;
                    blockMoveBefore = other.gameObject.transform.parent.position.x;
                    transform.Translate(blockMove, 0, 0);
                    Debug.Log(blockMove);
                    Debug.Log(other.gameObject.name);
                }
                
            }
        }
    }
}
