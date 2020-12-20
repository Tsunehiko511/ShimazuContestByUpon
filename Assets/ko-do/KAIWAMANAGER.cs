using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KAIWAMANAGER : MonoBehaviour
{
    public Text kaiwatext;
    public float kaiwacount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            kaiwacount ++;
        }
        if(kaiwacount == 1)
        {
            kaiwatext.text = "シレンハミッツアルヒトツクリアスルゴトニドンドンムズカシクナッテイク";
        }
        if(kaiwacount == 2)
        {
            kaiwatext.text = "カクシレンノナカニハヒントガカイテアルカラソレヲヨクヨムヨウニ";
        }
        if(kaiwacount == 3)
        {
            kaiwatext.text = "シッパイシタリシンダリシタラソレデオマエノレンアイハオワリダ";
        }
        if(kaiwacount == 4)
        {
            kaiwatext.text = "バグッタラヤリナオシテクレソレハドウニモナランカラスマン";
        }
        if(kaiwacount == 5)
        {
            SceneManager.LoadScene("SAISYO");
        }
    }
}
