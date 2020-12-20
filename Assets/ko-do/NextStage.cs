using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class NextStage : MonoBehaviour
{
    [SerializeField] string nextStageName = default;
    [SerializeField] StageManager stageManager = default;
    [SerializeField] GameObject NextImage = default;
    [SerializeField] Text SHIRENTEXT = default;
    [SerializeField] string message = default;

    private void OnTriggerEnter(Collider collider)
    {
        if (stageManager.isClear)
        {
            PlayerScript_01 player = collider.GetComponent<PlayerScript_01>();
            if (player == null)
            {
                NextImage.SetActive(true);
                SHIRENTEXT.text = message;
                StartCoroutine(NextStop());
            }
        }
    }

    IEnumerator NextStop()
    {
        yield return new WaitForSeconds(2);
        SHIRENTEXT.text = "イコウカンリョウ";
        yield return new WaitForSeconds(1);
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene(nextStageName);
    }
}
