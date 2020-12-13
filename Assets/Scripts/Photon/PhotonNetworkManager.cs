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
    [SerializeField] GameObject[] playerPrefabs;
    [SerializeField] Transform[] playerPositions;
    // [SerializeField] GameObject lobbyButton;

    void Start()
    {
        PhotonNetwork.IsMessageQueueRunning = true;

        if (PhotonNetwork.IsConnected == false)
        {
            GameObject localGamePlayer = Instantiate(playerPrefabs[1], playerPositions[0].position, Quaternion.identity);
            return;
        }
        PhotonNetwork.CurrentRoom.IsOpen = false;
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        GameObject gamePlayer = PhotonNetwork.Instantiate("Prefabs/Player" + PhotonMatching.id, playerPositions[PhotonMatching.id].position, Quaternion.identity);
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


