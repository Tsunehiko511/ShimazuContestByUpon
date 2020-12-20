using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(3 * Time.deltaTime, 0, 0); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "turisage")
        {
            Destroy(gameObject);
        }
    }
}
