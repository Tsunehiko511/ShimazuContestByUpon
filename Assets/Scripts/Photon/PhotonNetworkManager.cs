using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// マッチングが成功したら、Playerを生成する
/// </summary>
public class PhotonNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] bool isBlue;
    [SerializeField] GameObject[] playerPrefabs;
    [SerializeField] Transform[] playerPositions;
    // [SerializeField] GameObject lobbyButton;

    void Start()
    {

        if (PhotonNetwork.IsConnected == false)
        {
            if (isBlue)
            {
                GameObject localGamePlayer = Instantiate(playerPrefabs[0], playerPositions[0].position, Quaternion.identity);
               // Instantiate(playerPrefabs[1], playerPositions[1].position, Quaternion.identity);

            }
            else
            {
                //GameObject localGamePlayer = Instantiate(playerPrefabs[1], playerPositions[1].position, Quaternion.identity);
               // Instantiate(playerPrefabs[0], playerPositions[0].position, Quaternion.identity);
            }
            return;
        }
        Invoke("Spawn", 0.75f);
        PhotonNetwork.CurrentRoom.IsOpen = false;
        GameObject gamePlayer = PhotonNetwork.Instantiate("Prefabs/Player" + PhotonMatching.id, playerPositions[PhotonMatching.id].position, Quaternion.identity);
    }

    void Spawn()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
    }

    // 将来使うかも
    /*
    public void OnLobbyButton()
    {
        if (PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("SAISYO");
            return;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
        // ボタンを消して
        PhotonNetwork.LeaveRoom();
    }
    */
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("SAISYO");
    }
}


