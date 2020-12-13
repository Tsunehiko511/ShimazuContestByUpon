using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class zinnseiyarinaosubotan : MonoBehaviour
{
    public Text tex;
    public Text tex1;
    public Text textsaikoutiku;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ONButton()
    {
      　　
        tex1.text = "";
        textsaikoutiku.text = "アラタナジンセイヲサイコウチクチュウ.....";
        StartCoroutine("yartinaoshi");
    }

    IEnumerator yartinaoshi()
    {
        yield return new WaitForSeconds(3);
        textsaikoutiku.text = "コウチクカンリョウ";
        Debug.Log("ok");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SAISYO");
        Debug.Log("ok");
    }
}
