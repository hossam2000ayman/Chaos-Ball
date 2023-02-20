using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f; 
    [SerializeField]
    float startingTime = 120f; //120 -1 ==> 119 118 117 , ...

    [SerializeField] Text countdownValue; //0 ==> 120 ===> operation ==> 119 118 117 , ...


    [SerializeField]
    private float delayBeforeRestarting = 3f;

    private float timeElapsed;
    private void Start()
    { 
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime; //for every second (-1)
        //convert from float to string datatypes
        // "0" ==> make timer as a whole number
        countdownValue.text = currentTime.ToString("0"); //whole number (1,2,3,4) not equal (4.5)

       
    }

    private void OnGUI()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
            Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75);
            GUI.Box(rect, "Time is Over");
            Rect rect2 = new Rect(Screen.width / 2 - 30, Screen.height / 2 - 25, 60, 50);
            GUI.Label(rect2, "Restarting");
            Time.timeScale = .25f;
            TimeToRestartScene();
        }
    }

    private void TimeToRestartScene()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeRestarting)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
            print("Restart the Game");
        }
    }

}
