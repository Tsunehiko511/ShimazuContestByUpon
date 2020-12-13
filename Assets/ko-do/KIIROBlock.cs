using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIIROBlock : MonoBehaviour
{
    Material mat;
    // 使わない
    bool ok;

    // インスペクターから青 or オレンジのスイッチのswitchを入れればいい
    public SwitchController switchController;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        // ok = ButtonConAO.iio;
        if (switchController.isOn)
        {
            mat.SetColor("_EmissionColor", new Color(1, 1, 0, 0));

        }
        else
        {
            mat.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
        }
        /*
        if (ok == true)
        {
            Debug.Log("ok");
            mat.SetColor("_EmissionColor", new Color(1,1,0,0));
        }
        if(ok == false)
        {
            mat.SetColor("_EmissionColor", new Color(0,0,0,0));
        }*/
    }
}
