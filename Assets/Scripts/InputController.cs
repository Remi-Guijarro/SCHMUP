using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BulletGun bulletGun = GetComponent<BulletGun>();
        bulletGun.Speed = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        GetComponent<Engines>().Speed = new Vector2(horizontalAxis, verticalAxis);
        if (Input.GetButton("Fire1"))
        {
            GetComponent<BulletGun>().Fire();
        }
    }
}
