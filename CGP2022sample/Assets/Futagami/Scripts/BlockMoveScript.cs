using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lr;
    public float move;
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move = speed * lr; 
        transform.Translate(move, 0, 0);

        if (block.transform.position.x < -8.0f)
        {
            lr = 1.0f;
        }
        else if (block.transform.position.x > 8.0f)
        {
            lr = -1.0f;
        }
    }
}
