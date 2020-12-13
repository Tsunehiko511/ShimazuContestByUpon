using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NANAIRO : MonoBehaviour
{
    
    Material mat;
    float R, G, B, A;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetColor("_EmissionColor", new Color(R,G,B,A));
        time -= 1 * Time.deltaTime;

        if(time <= 0)
        {
            R = Random.Range(0, 1.0f);
            G = Random.Range(0, 1.0f);
            B = Random.Range(0, 1.0f);
            A = Random.Range(0, 1.0f);
            time = 0.2f;
        }
      
    }
}
