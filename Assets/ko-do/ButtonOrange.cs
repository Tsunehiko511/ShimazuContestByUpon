using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOrange : MonoBehaviour
{
    public static bool orangeiio;
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
        if (collider.gameObject.tag == "PlayerOrange")
        {
            Debug.Log("iio");
            transform.position = new Vector3(52.9f, 4.19f, -1.77f);
            orangeiio = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerOrange")
        {
            transform.position = new Vector3(52.9f, 4.3f, -1.77f);
            orangeiio = false;
        }
    }
}
