using System.Collections;
using UnityEngine;
using Photon.Pun;
public class PlayerScript_01 : MonoBehaviourPun
{
    private Rigidbody rb;
    public float jumpSpeed;
    private bool isJumping = false;
    public float speed;

    // 同期位置：これと離れすぎると瞬間移動するようにする
    Vector3 recievePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (PhotonNetwork.IsConnected)
        {
            if (photonView.IsMine == false)
            {
                // rb.isKinematic = true;
                // GetComponentInChildren<SphereCollider>().isTrigger = true;
                recievePosition = transform.position;
            }
            else
            {
                StartCoroutine(SendPosition());
            }
        }
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (photonView.IsMine == false)
            {
                //もし離れすぎていたら、同期する
                if (Vector2.Distance(recievePosition, transform.position) > 1f)
                {
                    Debug.Log("もし離れすぎていたら、同期する");
                    transform.position = recievePosition;
                }
                //大好きよ💛
                recievePosition = transform.position;
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

    IEnumerator SendPosition()
    {
        while (true)
        {
            photonView.RPC(nameof(SetPosition), RpcTarget.Others, transform.position);
            yield return new WaitForSeconds(1f);
        }
    }

    [PunRPC]
    public void SetPosition(Vector3 position)
    {
        recievePosition = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
