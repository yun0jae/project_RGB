using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldREffectScript : MonoBehaviour
{
    public float ShakeAmount;
    float ShakeTime = 20.0f;
    Vector3 initialPosition;

    GameObject player;
    public WorldRScript playerMoveR;

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerMoveR = GameObject.Find("WorldR").GetComponent<WorldRScript>();
    }

    void Update()
    {
        if (playerMoveR.shake)
        {
            initialPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime = Time.deltaTime;
        }

    }

}
