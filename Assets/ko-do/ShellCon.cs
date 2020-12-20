using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCon : MonoBehaviour
{
    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 1000;
    public bool ok;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ok = ShellButton.isok;
        if(ok == true)
        {
            ShellButton.isok = false;
            // 弾丸の複製
            GameObject bullets = Instantiate(bullet) as GameObject;

            Vector3 force;

            force = this.gameObject.transform.forward * speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
    }
}
