using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerScript_01 : MonoBehaviourPun
{
    private Rigidbody rb;
    public float jumpSpeed;
    private bool isJumping = false;
    public float speed;
    public  GameObject NextImage;
    public Text SHIRENTEXT;
    // Start is called before the first frame update
    void Start()
    {
        NextImage = GameObject.Find("NextImage");
        SHIRENTEXT = GameObject.Find("NextText").GetComponent<Text>();
        NextImage.SetActive(false);
        rb = GetComponent<Rigidbody>();
        if (PhotonNetwork.IsConnected)
        {
            if (photonView.IsMine == false)
            {
                rb.isKinematic = true;
                GetComponentInChildren<SphereCollider>().isTrigger = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (photonView.IsMine == false)
            {
                //大好きよ💛
                return;
            }
        }

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

　　private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "NextStage")
        {
            NextImage.SetActive(true);
            SHIRENTEXT.text = "ツギノシレンニイコウチュウ...";
            StartCoroutine(NextStop());
        }
    }

    IEnumerator NextStop()
    {
        yield return new WaitForSeconds(2);
        SHIRENTEXT.text = "イコウカンリョウ";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage02");
    }

}
