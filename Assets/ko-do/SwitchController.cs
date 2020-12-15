using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // 押されているかどうか
    public bool isOn;

    // インスペクターから、個別にタグの名前を設定することで、１つのスクリプトでも青とオレンジを分けることができる
    [SerializeField] string tagType;// PlayerかPlayerOrangeが入る

    Vector3 defaultPosition; // 元々の位置：スイッチから離れた時に戻すため
    [SerializeField] float downValue = default;// 0.08fか0.14f; インスペクターで調節する必要あり

    void Start()
    {
        defaultPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.B) && tagType == "Player")
            {
                isOn = true;
            }
            if (Input.GetKey(KeyCode.O) && tagType == "PlayerOrange")
            {
                isOn = true;
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == tagType)
        {
            // ボタンの位置を下げる
            transform.position = defaultPosition - new Vector3(0, downValue, 0);
            isOn = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == tagType)
        {
            transform.position = defaultPosition;
            isOn = false;
        }
    }


}
