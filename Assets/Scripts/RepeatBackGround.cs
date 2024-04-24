using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{

    Vector3 StartPos; // The starting position of the background
    float repeatWidth; 
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position; // the start position of the background
        repeatWidth = GetComponent<BoxCollider2D>().size.x/2; 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < StartPos.x - repeatWidth)
        {
            transform.position = StartPos; //snap back to starting position, so scroll starts over
        }
    }
}
