using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject tobira;
    // ButtonConAO.ioをstaticにするよりも、個別に受け取った方がスクリプトが減る(修正が減る)
    public SwitchController blueSwitch;
    public SwitchController orangeSwitch;
    public bool isClear = false;

    void Update()
    {
        if (isClear)
        {
            // クリア済みなら処理しない
            return;
        }
        // ButtonConAO.ioをstaticにするよりも、個別に受け取った方がスクリプトが減る
        if (blueSwitch.isOn == true && orangeSwitch.isOn == true)
        {
            isClear = true;
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        int angle = 0;
  
        while (angle > -144)
        {
            angle--;
            tobira.transform.eulerAngles = new Vector3(0, angle, 0);
            yield return null;
        }
    }
}
