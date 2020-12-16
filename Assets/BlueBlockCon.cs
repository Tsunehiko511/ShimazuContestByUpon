using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockCon : MonoBehaviour
{
    public GameObject Cam;
     AudioSource audio;
    public AudioClip sound;
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
        if (collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(sound);
            Shake(Cam);
            StartCoroutine(matu());
        }
    }
    public void Shake(GameObject Cam)
    {
        iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
    }

    IEnumerator matu()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
