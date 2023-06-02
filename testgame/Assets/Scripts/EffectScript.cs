using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectScript : MonoBehaviour
{
    public float ShakeAmount;
    float ShakeTime = 20.0f;
    Vector3 initialPosition;

    GameObject player;

    public void VibrateForTime(float time)
    {
        ShakeTime = time;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        initialPosition = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
        transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
        ShakeTime = Time.deltaTime;
    }

}
