using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class PhotonMatching : MonoBehaviourPunCallbacks
{
    public static int id; // 先に入ったかどうかを判断
    public static bool isOnline; // 先に入ったかどうかを判断
    [SerializeField] GameObject matchingButton;
    [SerializeField] GameObject text;
    private void Start()
    {
        matchingButton.SetActive(false);
        text.SetActive(false);
        // Photonに接続
        Connect();
    }

    // Photonに接続
    void Connect()
    {
        //Photonに接続できていなければ
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();   //Photonに接続する
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {
                PhotonNetwork.NickName = "player" + Random.Range(1, 99999);
            }
            matchingButton.SetActive(true);
        }
    }


    // マッチングボタンを押すと発動
    public void OnMatchingButton()
    {
        text.SetActive(true);
        matchingButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
    }

    // ランダムマッチングに失敗
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        // 部屋を作る
        id = 0;
        PhotonNetwork.CreateRoom(null, CreateRoomOptions(), null);
    }

    // 部屋の設定を決めるもの
    RoomOptions CreateRoomOptions()
    {
        //作成する部屋の設定
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;   //ロビーで見える部屋にする
        roomOptions.IsOpen = true;      //他のプレイヤーの入室を許可する
        roomOptions.MaxPlayers = 2;    //入室可能人数を設定
        //ルームカスタムプロパティで部屋作成者を表示させるため、作成者の名前を格納
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable()
        {
            { "RoomCreator",PhotonNetwork.NickName }
        };

        //ロビーにカスタムプロパティの情報を表示させる
        roomOptions.CustomRoomPropertiesForLobby = new string[]
        {
            "RoomCreator",
        };
        return roomOptions;
    }

    void OnGUI()
    {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }

    // 参加に成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        id = 1;
        Debug.Log("参加に成功");
        CheckMatching(PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
    }

    // 他プレイヤーが参加した時に呼ばれるコールバック
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        id = 0;
        Debug.Log("他プレイヤーが参加した時に呼ばれる");
        base.OnPlayerEnteredRoom(newPlayer);
        CheckMatching(PhotonNetwork.CurrentRoom.PlayerCount, PhotonNetwork.CurrentRoom.MaxPlayers);
    }

    // 他プレイヤーが退出した時に呼ばれるコールバック
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("他プレイヤーが退出した");
    }


    void CheckMatching(int currentRoomCount, int max)
    {
        if (currentRoomCount == max)
        {
            PhotonNetwork.IsMessageQueueRunning = false;
            SceneManager.LoadScene("Stage01");
        }
    }
}
