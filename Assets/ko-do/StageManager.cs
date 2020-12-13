using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject tobira;
    bool ao;
    bool kiiro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ao = ButtonConAO.iio;
        kiiro = ButtonOrange.orangeiio;

        if(ao == true && kiiro == true)
        {
            tobira.transform.rotation = new Quaternion(0, -111.08f,0, 0);
        }
    }
}
