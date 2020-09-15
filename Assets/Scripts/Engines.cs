using UnityEngine;
using System.Collections;


public class Engines : MonoBehaviour
{
    [SerializeField]
    private Vector2 speed;
    public Vector2 Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            this.speed = value;
        }
    }


    public Vector2 Position
    {
        get
        {
            return this.transform.position;
        }
        private set
        {
            this.transform.position = value;
        }
    }   

    // Update is called once per frame
    void Update()
    {
        this.Position += speed * GetComponent<BaseAvatar>().MaxSpeeed * Time.deltaTime;
    }
}
