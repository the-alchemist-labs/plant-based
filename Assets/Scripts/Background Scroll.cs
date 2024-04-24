using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Vector3 StartPos; // The starting position of the background
    private float repeatWidth;
    public float speed; //The speed the background will scroll
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position; // the start position of the background
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 1) //as long as speed is higher then 1, so no negetive speed will work
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); //Some unity thingy that makes the background move
        }
        else transform.Translate(Vector3.left * Time.deltaTime); //incase it's under 1 or negetive, the default will be 1

        if (transform.position.x < StartPos.x - repeatWidth)
        {
            transform.position = StartPos; //snap back to starting position, so scroll starts over
        }
    }
}
