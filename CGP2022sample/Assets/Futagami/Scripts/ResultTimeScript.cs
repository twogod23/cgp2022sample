using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultTimeScript : MonoBehaviour
{
     //スコアを表示するオブジェクトを指定
    public TextMeshProUGUI timetext;
    //得点の指定
    float time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        time = GoalScript.GetGoaltime();
        timetext.text = "TIME : " + time.ToString("f1") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
