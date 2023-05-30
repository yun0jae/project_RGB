using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destright : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool keydown = Input.GetKeyDown(KeyCode.D);
        if (keydown)
        {
            Destroy(this);
        }
    }
}
