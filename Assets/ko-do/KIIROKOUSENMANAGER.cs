using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIIROKOUSENMANAGER : MonoBehaviour
{
    bool iesu;
    Animator animator,animator1,animator2;
    public GameObject kiiro1, kiiro2, kiiro3;
    bool modore;
    // Start is called before the first frame update
    void Start()
    {
         animator = kiiro1.GetComponent<Animator>();
         animator1 = kiiro2.GetComponent<Animator>();
         animator2 = kiiro3.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        modore = kiirobutton.modosu;
        iesu = kiirobutton.iio;
        Debug.Log(iesu);
        Debug.Log(modore + "modore");
        if(iesu == true)
        {
            kiirobutton.iio = false;
            kiiro();
        }
        if(modore == true)
        {
            kiirobutton.modosu = false;
            modoru();
        }
    }

    void kiiro()
    {
        animator.SetBool("modoru", false);
        animator1.SetBool("modoru", false);
        animator2.SetBool("modoru", false);
        animator.SetBool("kiiro", true);
            StartCoroutine(one());
            StartCoroutine(second());
        
    }

    void modoru()
    {
        animator.SetBool("kiiro", false);
        animator1.SetBool("kiiro", false);
        animator2.SetBool("kiiro", false);
       // Debug.Log("iiiii");
       // animator.SetBool("modoru", true);
       // StartCoroutine(modoruone());
       // StartCoroutine(modorusecond());
    }

    IEnumerator one()
    {
        yield return new WaitForSeconds(1);
        animator1.SetBool("kiiro", true);
        Debug.Log(1);
    }
    IEnumerator second()
    {
        yield return new WaitForSeconds(2);
        animator2.SetBool("kiiro", true);
        Debug.Log(2);
    }

    IEnumerator modoruone()
    {
        yield return new WaitForSeconds(2);
        animator1.SetBool("modoru", true);
    }
    IEnumerator modorusecond()
    {
        yield return new WaitForSeconds(3);
        animator2.SetBool("modoru", true);
    }
}
