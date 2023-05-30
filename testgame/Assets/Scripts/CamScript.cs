using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    GameObject player;
    WorldREffectScript worldREffectScript;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        worldREffectScript = GameObject.Find("Main Camera").GetComponent<WorldREffectScript>();
        worldREffectScript.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 campos = this.transform.position;
        transform.position = new Vector3(player.transform.position.x, campos.y, player.transform.position.z);

        if (gameManager.stages[1].activeSelf)
        {
            worldREffectScript.enabled = true;
        }


    }
}
