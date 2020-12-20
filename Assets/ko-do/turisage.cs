using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turisage : MonoBehaviour
{
    GameObject Cam;
    public GameObject button;
    Rigidbody rb;
    void Start()
    {
        Cam = GameObject.Find("Main Camera");
        rb = button.GetComponent<Rigidbody>();
    }
   void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Shell")
        {
            rb.isKinematic = false;
            StartCoroutine(kieru());
            iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
        }
    }

    IEnumerator kieru()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
