using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCon : MonoBehaviour
{
    GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "toge")
        {
            iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
            StartCoroutine(matu());
        }
    }

    IEnumerator matu()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
