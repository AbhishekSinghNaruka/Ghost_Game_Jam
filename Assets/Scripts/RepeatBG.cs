using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBG : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + -5 * Time.deltaTime, transform.position.y);
        if (transform.position.x < -18) {
            transform.position = new Vector2(18f, transform.position.y);
        }
    }

}
