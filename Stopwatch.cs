using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public float timeStart = 0;
    public Text textBox;

    void Start()
    {
        textBox.text = timeStart.ToString();
    }


    void Update()
    {
        timeStart += Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString();
    }
}
