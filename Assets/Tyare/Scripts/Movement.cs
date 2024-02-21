using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            gameObject.transform.Translate(0f,0f,.01f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(0f, 0f,-.01f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-.01f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(.01f, 0f, 0f);
        }


    }
}
