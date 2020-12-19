using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downfloorCon : MonoBehaviour
{
    Animation anim;
    public GameObject Cam;
 
    // Start is called before the first frame update
    void Start()
    {

        Cam = GameObject.Find("Main Camera");
        anim = this.gameObject.GetComponent<Animation>();
    }

    
    // Update is called once per frame
    void Update()
    {
 
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Animator animetor = GetComponent<Animator>();
            animetor.SetTrigger("kirikaeee");
            iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
        }
  
    }

  
}
