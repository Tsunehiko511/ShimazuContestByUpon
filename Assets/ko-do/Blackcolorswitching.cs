using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackcolorswitching : MonoBehaviour
{
    GameObject redblock, redblock1, redblock2, redblock3, redblock4, redblock5, redblock6, redblock7, redblock8;
    // Start is called before the first frame update
    void Start()
    {
        redblock = GameObject.Find("RedBlock");
        redblock1 = GameObject.Find("RedBlock1");
        redblock2 = GameObject.Find("RedBlock2");
        redblock3 = GameObject.Find("RedBlock3");
        redblock4 = GameObject.Find("RedBlock4");
        redblock5 = GameObject.Find("RedBlock5");
        redblock6 = GameObject.Find("RedBlock6");
        redblock7 = GameObject.Find("RedBlock7");
        redblock8 = GameObject.Find("RedBlock8");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
