using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        BulletGun bulletGun = GetComponent<BulletGun>();
        bulletGun.Speed = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BulletGun>().Fire();        
    }
}
