using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sli : MonoBehaviour
{

    public int timer;
    public Slider timerSlider;

    // Use this for initialization
    void Start()
    {
        timer = 1000;
      //  timerSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {   
        timerSlider.value = timer--;

    }
}
