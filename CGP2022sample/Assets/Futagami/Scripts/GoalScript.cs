using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public static float goaltime;
    public GameObject goaltimeTxt;
    public GameObject goalTxt;
    public GameObject goalBlock;
    private bool goal;
    private float loadSceneTime;

    // Start is called before the first frame update
    void Start()
    {
        goaltime = 0.0f;
        loadSceneTime = 2.0f;
        goalTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (goal == true)
        {
           goalBlock.GetComponent<Renderer>().material.color = Color.HSVToRGB(Time.time % 1, 1, 1);
           
           /* loadSceneTime -= Time.deltaTime;

            if (loadSceneTime <= 0)
            {
                //SceneManager.LoadScene("GoalScene");
                Debug.Log("goaltime");
            }*/
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (goal == false)
        {
            if (other.gameObject.CompareTag("GoalBlockSurface"))
            {
                goaltime = CountDownTimeScript.GetTime();
                Destroy(goaltimeTxt);
                goal = true;
                goalTxt.SetActive(true);
                StartCoroutine("SceneChange");
            }
        }
    }

    public static float GetGoaltime()
    {
        return goaltime;
    }

    IEnumerator SceneChange()
    {
        //停止する秒数を指定
        yield return new WaitForSeconds(loadSceneTime);
        //停止後の処理
        SceneManager.LoadScene("ClearScene");
    }
}
