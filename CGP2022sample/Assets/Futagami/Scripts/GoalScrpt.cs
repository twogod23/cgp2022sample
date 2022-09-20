using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScrpt : MonoBehaviour
{
    public static float goaltime;
    public GameObject goaltimeTxt;
    private bool goal;
    private float loadSceneTime;

    // Start is called before the first frame update
    void Start()
    {
        goaltime = 0.0f;
        loadSceneTime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (goal == true)
        {
            loadSceneTime -= Time.deltaTime;

            if (loadSceneTime <= 0)
            {
                //SceneManager.LoadScene("GoalScene");
                Debug.Log("goaltime");
            }
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
            }
        }
    }

    public static float GetGoaltime()
    {
        return goaltime;
    }
}
