using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    
    private float shootTime = 0;　　//表示子弹的生成时间间隔 用来控制子弹的发射间隔

    private float shootTimerInterval = 0.5f;　　//表示子弹的间隔这个是一个固定的时间

    private bool can_shoot = true;
    
    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;　　//让子弹的时间控制器不断加等时间间隔

        if (shootTime > shootTimerInterval)
        {
            //如果子弹发射的时间间隔超过时间控制器　　那么我们就发射子弹

            shootTime = 0; //让子弹的时间间隔回复到初始的情况下

            can_shoot = true;
        }

        Shoot();
    }

    void Shoot()
    {
        if (!can_shoot)
            return;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            can_shoot = false;
            shootTime = 0;
        }
    }
}
