using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellButton : MonoBehaviour
{
    public static bool isok;
    AudioSource audio;
    public AudioClip sound;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "PlayerOrange")
        {
            isok = true;
            button.transform.localScale = new Vector3(1, 0.5f, 1);
            audio.PlayOneShot(sound);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "PlayerOrange")
        {
            isok = false;
            button.transform.localScale = new Vector3(1, 0.75f, 1);
        }
    }
}
