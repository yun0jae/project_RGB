using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool keydown = Input.GetKeyDown(KeyCode.W);
        if (keydown)
        {
            Destroy(this);
        }
    }
}
