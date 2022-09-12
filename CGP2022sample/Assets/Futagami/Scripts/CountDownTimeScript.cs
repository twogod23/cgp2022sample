using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimeScript : MonoBehaviour
{
    //カウントダウンする時間の定義
    public float countdown = 10.0f;

    //時間を表示するテキストの定義
    public Text timetext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウン
        countdown -= Time.deltaTime;

        //時間の表示
        timetext.text = countdown.ToString("f1") + "s";

        //制限時間になったら終了
        if (countdown < 0)
        {
            SceneManager.LoadScene("GameoverScene");
        }
        
           
    }
}
