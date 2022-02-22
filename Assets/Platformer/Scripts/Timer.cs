using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 400;

    public TMP_Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("000");

        if (currentTime <= 0)
        {
            Debug.Log("Times up!");
            currentTime = 0;
        }

    }
}
