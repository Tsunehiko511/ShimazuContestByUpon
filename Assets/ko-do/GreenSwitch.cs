using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSwitch : MonoBehaviour
{
    // ボタンが押されたら、Playerを回収して、どちらかを重くする
    [SerializeField] PlayerScript_01[] players;
    AudioSource audio;
    public AudioClip sound;

    Vector3 defaultPosition; // 元々の位置：スイッチから離れた時に戻すため
    [SerializeField] float downValue = default;// 0.08fか0.14f; インスペクターで調節する必要あり


    private void Start()
    {
        audio = GetComponent<AudioSource>();
        defaultPosition = transform.position;
    }
    void SwitchWeight()
    {
        players = GameObject.FindObjectsOfType<PlayerScript_01>();
        float tmpWeight = players[0].GetComponent<Rigidbody>().mass;
        players[0].GetComponent<Rigidbody>().mass = players[1].GetComponent<Rigidbody>().mass;
        players[1].GetComponent<Rigidbody>().mass = tmpWeight;
    }

    void OnTriggerStay(Collider collider)
    {
        // ボタンの位置を下げる
        transform.position = defaultPosition - new Vector3(0, downValue, 0);
    }
    void OnTriggerExit(Collider collider)
    {
        Invoke("ResetPosition", 0.2f);
    }

    void ResetPosition()
    {
        transform.position = defaultPosition;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (transform.position == defaultPosition)
        {
            SwitchWeight();
            audio.PlayOneShot(sound);
        }
    }
}
