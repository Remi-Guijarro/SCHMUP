using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
   void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        GetComponent<Engines>().Speed = new Vector2(horizontalAxis, verticalAxis);
        if (Input.GetKey("space")) {
            GetComponent<BulletGun>().Fire();
        }
    }
}
