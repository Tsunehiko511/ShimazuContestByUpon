using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonConAO : MonoBehaviour
{
    public static bool iio;
    Vector3 defaultPosition; // 元々の位置：スイッチから離れた時に戻すため
    [SerializeField] float downValue = default;// 0.14f; インスペクターで調節する必要あり

    void Start()
    {
        defaultPosition = transform.position;
    }


    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("iio");
            transform.position = defaultPosition - new Vector3(0, downValue, 0);
            iio = true;
        }
      
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            transform.position = defaultPosition;
            iio = false;
        }
    }
}
