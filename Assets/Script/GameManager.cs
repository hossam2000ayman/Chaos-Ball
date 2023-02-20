using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GoalScript blue, green, red, orange;
    private bool isGameOver = true;

    //using in navigate to next level after finish main level
    [SerializeField]
    private float delayBeforeLoading = 4f;

    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;


    private void Update()
    {
        //if all of the goals are solved then the game is over
        isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved;
    }

    private void OnGUI()
    {
        if (isGameOver)
        {
            if (sceneNameToLoad == "Main")
            {
                Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75);
                GUI.Box(rect, "Game Over");
                Rect rect2 = new Rect(Screen.width / 2 - 30, Screen.height / 2 - 25, 60, 50);
                GUI.Label(rect2, "Good Job");
                Time.timeScale = 0.5f;
                
            }
             if (sceneNameToLoad == "Second Level")
            {
                Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 75);
                GUI.Box(rect, "Level Completed");
                Rect rect2 = new Rect(Screen.width / 2 - 30, Screen.height / 2 - 25, 90, 75);
                GUI.Label(rect2, "Loading to Next Level");
                Time.timeScale = 0.5f;

                TimeToLoadScene();
            }
            
        }
    }

    private void TimeToLoadScene()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
            Time.timeScale = 1f;
        }
    }

    
}
