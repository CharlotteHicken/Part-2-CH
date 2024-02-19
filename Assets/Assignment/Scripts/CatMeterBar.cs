using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatMeterBar : MonoBehaviour
{
    public Slider slider;

    public void CatMeter(float meter)
    {
        slider.value += meter;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
