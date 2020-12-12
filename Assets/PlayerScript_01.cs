using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript_01 : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpSpeed;
    private bool isJumping = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W) && isJumping == false)
        {
            rb.velocity = Vector3.up * jumpSpeed;
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
        }
        else
        {
            this.transform.localScale = new Vector3(0.5f ,0.5f, 0.5f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

}
