using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destdown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool keydown = Input.GetKeyDown(KeyCode.S);
        if (keydown)
        {
            Destroy(this);
        }
    }
}
