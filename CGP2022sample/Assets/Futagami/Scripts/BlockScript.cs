using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    //ブロックの上側
    public GameObject onBlock;
    //ブロックの下側
    public GameObject blockBase;
    //オーディオコンポーネントの指定
    private AudioSource soundeffect;
    //オーディオの指定
    public AudioClip sound;
    //変更後の色を指定
    public Material colorAfter;
    // Start is called before the first frame update
    void Start()
    {
        soundeffect = onBlock.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //オーディオの再生
            soundeffect.PlayOneShot(sound);
            //色を変化
            blockBase.GetComponent<Renderer>().material.color = colorAfter.color;
            onBlock.GetComponent<Renderer>().material.color = colorAfter.color;
        }
    }
}
