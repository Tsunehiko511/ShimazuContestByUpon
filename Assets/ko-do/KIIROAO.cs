using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIIROAO : MonoBehaviour
{
    Material mat;
    bool ok;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        ok = ButtonConAO.iio;

        if(ok == true)
        {
            Debug.Log("ok");
            mat.SetColor("_EmissionColor", new Color(1,1,0,0));
        }
        if(ok == false)
        {
            mat.SetColor("_EmissionColor", new Color(0,0,0,0));
        }
    }
}
