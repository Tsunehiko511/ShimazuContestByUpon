using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlockControl : MonoBehaviour
{
     AudioSource audio;
    public AudioClip sound;
    public GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerOrange")
        {
            audio.PlayOneShot(sound);
            Shake(Cam);
            Destroy(gameObject);
        }
    }
    public void Shake(GameObject Cam)
    {
        iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
    }
}
