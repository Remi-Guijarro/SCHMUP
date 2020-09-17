using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletGun : MonoBehaviour
{
   void Update()
    {
        GetComponent<BulletGun>().Fire();
    }
}
