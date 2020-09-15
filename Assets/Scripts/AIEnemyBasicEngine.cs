using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    void Update()
    {
        float horizontalAxis = -1f;
        float verticalAxis = 0f;
        GetComponent<Engines>().Speed = new Vector2(horizontalAxis, verticalAxis);
    }
}
