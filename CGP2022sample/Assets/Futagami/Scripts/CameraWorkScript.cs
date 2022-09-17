using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorkScript : MonoBehaviour
{
    //追跡するゲームオブジェクトの定義
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //追跡するゲームオブジェクトの指定
        //player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //追跡するゲームオブジェクトの座標取得
        Vector3 playerpos = player.transform.position;

        //カメラの座標指定
        transform.position = new Vector3 (0, playerpos.y + 3, -10);
    }
}
