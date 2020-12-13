using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIIROORANGE : MonoBehaviour
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
        //ここをかえろ
        ok = ButtonOrange.orangeiio;

        if (ok == true)
        {
            Debug.Log("ok");
            mat.SetColor("_EmissionColor", new Color(1, 1, 0, 0));
        }
        if (ok == false)
        {
            mat.SetColor("_EmissionColor", new Color(0, 0, 0, 0));
        }
    }
}
