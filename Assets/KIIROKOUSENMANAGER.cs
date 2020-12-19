using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIIROKOUSENMANAGER : MonoBehaviour
{
    bool iesu;
    Animator animator,animator1,animator2;
    public GameObject kiiro1, kiiro2, kiiro3;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = kiiro1.GetComponent<Animator>();
        Animator animator1 = kiiro2.GetComponent<Animator>();
        Animator animator2 = kiiro3.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        iesu = kiirobutton.iio;
        Debug.Log(iesu);
        if(iesu == true)
        {
            animator.SetBool("kiiro", true);
            StartCoroutine(one());
            StartCoroutine(second());
        }
    }

    IEnumerator one()
    {
        yield return new WaitForSeconds(0.2f);
        animator1.SetBool("kiiro", true);
        Debug.Log(1);
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(0.4f);
        animator2.SetBool("kiiro", true);
        Debug.Log(2);
    }
}
