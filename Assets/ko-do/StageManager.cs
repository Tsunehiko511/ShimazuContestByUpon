﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject tobira;
    // ButtonConAO.ioをstaticにするよりも、個別に受け取った方がスクリプトが減る(修正が減る)
    // bool ao;
    // bool kiiro;
    public SwitchController blueSwitch;
    public SwitchController orangeSwitch;
    // Update is called once per frame
    void Update()
    {
        // ButtonConAO.ioをstaticにするよりも、個別に受け取った方がスクリプトが減る
        // ao = ButtonConAO.iio;
        // kiiro = ButtonOrange.orangeiio;
        // if (ao == true && kiiro == true)
        if (blueSwitch.isOn == true && orangeSwitch.isOn == true)
        {
            tobira.transform.rotation = new Quaternion(0, -111.08f,0, 0);
        }
    }
}
