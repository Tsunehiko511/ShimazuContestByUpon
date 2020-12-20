using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class sanBlack : MonoBehaviourPun
{
    [SerializeField] static string tagName;
    AudioSource audio;
    public AudioClip sound;
    public GameObject Cam;

    void Start()
    {
        Cam = GameObject.Find("Main Camera");
        audio = GetComponent<AudioSource>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (PhotonNetwork.IsConnected)
        {
            if (photonView.IsMine == false)
            {
                // Photonの時、自分以外は処理しない
                return;
            }
        }
        if (collision.gameObject.tag == tagName)
        {
            SendBreak();
        }
    }

    void SendBreak()
    {
        if (PhotonNetwork.IsConnected)
        {
            photonView.RPC(nameof(BreakBlock), RpcTarget.All);
        }
        else
        {
            BreakBlock();
        }
    }

    [PunRPC]
    void BreakBlock()
    {
        audio.PlayOneShot(sound);
        Shake(Cam);
        Destroy(gameObject);
    }

    public void Shake(GameObject Cam)
    {
        iTween.ShakePosition(Cam, iTween.Hash("x", 0.3f, "y", 0.3f, "time", 0.5f));
    }
}
