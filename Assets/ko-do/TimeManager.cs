using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    public float GameTime = 60;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameTime >= 0)
        {
            GameTime -= Time.deltaTime;
        }
        text.text = "00:" + GameTime.ToString("F0");
        if(GameTime <= 9)
        {
            text.text = "00:0" + GameTime.ToString("F0");
        }
        if(GameTime <= 0)
        {
            text.text = "00:00";
            StartCoroutine("Overdaun");
        }


    }

   IEnumerator Overdaun()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("OWARI");
    }
}
