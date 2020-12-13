using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConAO : MonoBehaviour
{
    public static bool iio;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("iio");
            transform.position = new Vector3(37.51469f, 1.9f, -1.77f);
            iio = true;
        }
      
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            transform.position = new Vector3(37.51469f, 2f, -1.77f);
            iio = false;
        }
    }
}
