using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenuSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void select()
    {
        //遅延処理メソッドの呼び出し
        StartCoroutine("SceneChange");
    }

    //コルーチンを利用して遅れて処理させる
    IEnumerator SceneChange()
    {
        //停止前の処理
        Debug.Log("check");
        //停止する秒数を指定 0.8f
        yield return new WaitForSeconds(0.8f);
        //停止後の処理
        SceneManager.LoadScene("MenuScene");
    }
}
