using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiirobutton : MonoBehaviour
{
    AudioSource audio;
    public AudioClip sound;
    public static bool iio;
    public static bool modosu;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(iio + "iio");
        Debug.Log(modosu + "modosu");
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "PlayerOrange")
        {

            transform.localScale = new Vector3(1, 0.5f, 1);

        }
        else
        {

            transform.localScale = new Vector3(1, 0.75f, 1);
        }
      
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "PlayerOrange")
        {
            iio = true;
            audio.PlayOneShot(sound);
        }
   
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "PlayerOrange")
        {
            modosu = true;
        }
    }
}
