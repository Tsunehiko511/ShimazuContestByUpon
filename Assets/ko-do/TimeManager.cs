using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    public int GameTime = 60;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        while (GameTime >= 0)
        {
            int h = GameTime / 60;
            int m = GameTime % 60;
            text.text = string.Format("{0:D2}:{1:D2}", h, m);
            if (GameTime <= 0)
            {
                StartCoroutine("Overdaun");
            }
            yield return new WaitForSeconds(1f);
            GameTime--;
            GameTime = Mathf.Max(0, GameTime);
        }
    }

    /*
    void Update()
    {
        if(GameTime >= 0)
        {
            GameTime -= Time.deltaTime;
            GameTime = Mathf.Max(0, GameTime);
        }
        text.text = string.Format("{0,2}:{0,2}", (int)(GameTime / 60), ((int)GameTime) % 60);

        if (GameTime <= 9)
        {
//            text.text = "00:0" + GameTime.ToString("F0");
        }
        if(GameTime <= 0)
        {
  //          text.text = "00:00";
            StartCoroutine("Overdaun");
        }
    }
    */

   IEnumerator Overdaun()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("OWARI");
    }
}
