using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    private float currentTime = 0;
    public float totalTime = 10.0f;
 
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        UpdateTimeDisplay();
    }


    void UpdateTimeDisplay()
    {

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        string timeString = string.Format("{0:0} : {1:00}", minutes, seconds);
        timeText.text = "Time " + timeString;
    }
}
