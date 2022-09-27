using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownTimeScript : MonoBehaviour
{
    //制限時間の定義
    public float settime;

    //カウントダウンする時間の定義
    private float countdown;

    //時間を表示するテキストの定義
    public Text timetext;

    //結果に表示する時間の定義
    public static float cleartime;

    //スタートを案内するテキストの定義
    public GameObject startTxt;

    // Start is called before the first frame update
    void Start()
    {
        //初期値の設定
        settime = 30.0f;
        countdown = settime;
        cleartime = 0.0f;
        startTxt.SetActive(true);
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
        
        //経過時間を計算
        cleartime = settime - countdown;

        //スタートを案内するテキストの消去
        if (cleartime > 2.0f)
        {
            Destroy(startTxt);
        }
    }

    //呼び出される時間
    public static float GetTime()
    {
        return cleartime;
    }
}
