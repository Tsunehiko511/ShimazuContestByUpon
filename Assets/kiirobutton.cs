using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobutton : MonoBehaviour
{
    AudioSource audio;
    public AudioClip sound;
    public static bool iio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(iio);
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            iio = true;
            transform.position = new Vector3(-14.4f, 22.5f, -1.13f);

        }
        else
        {
            iio = false;
            transform.position = new Vector3(-14.4f, 23f, -1.13f);
        }
      
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            audio.PlayOneShot(sound);
        }
    }
}
