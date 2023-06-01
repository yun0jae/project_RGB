using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 campos = this.transform.position;
        transform.position = new Vector3(player.transform.position.x, campos.y, player.transform.position.z);

        
    }
}
