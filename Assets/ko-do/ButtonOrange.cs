using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOrange : MonoBehaviour
{
    public static bool orangeiio;
    Vector3 defaultPosition; // 元々の位置：スイッチから離れた時に戻すため
    float downValue = 0.14f;

    void Start()
    {
        defaultPosition = transform.position;
    }


    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerOrange")
        {
            Debug.Log("iio");
            transform.position = defaultPosition - new Vector3(0, downValue, 0);
            orangeiio = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "PlayerOrange")
        {
            transform.position = defaultPosition;
            orangeiio = false;
        }
    }
}
