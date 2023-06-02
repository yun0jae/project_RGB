using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;
    public GameObject player;
    public WorldRScript playerMoveR;
    public WorldBScript playerMoveB;
    public GameObject Object;


    Rigidbody rigid;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("player");

        playerMoveR = GameObject.Find("WorldR").GetComponent<WorldRScript>();
        playerMoveB = GameObject.Find("WorldB").GetComponent<WorldBScript>();

    }

    void Start()
    {

    }

    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        //BLUE
        if (gameManager.stages[0].activeSelf)
        {
            if (collision.transform.CompareTag("Goal"))
            {
                playerMoveB.goal = true;
                Debug.Log("BLUE goal reached");
            }
        }

            //RED
            if (gameManager.stages[1].activeSelf)
        {
            if (collision.transform.CompareTag("Object"))
            {
                playerMoveR.objectR = true;
                Debug.Log("RED object gained");
            }

            if (collision.transform.CompareTag("Goal"))
            {
                playerMoveR.goal = true;
                Debug.Log("RED goal reached");
            }

            if (collision.transform.CompareTag("Reset"))
            {
                playerMoveR.InitRound();
            }
        }
            

    }


    private void OnCollisionStay(Collision collision)
    {
        //BLUE
        if (gameManager.stages[0].activeSelf)
        {
            if (collision.transform.CompareTag("Object"))
            {
                playerMoveB.objectB = true;
                Debug.Log("BLUE object gained");
            }
        }

        //RED
        if (gameManager.stages[1].activeSelf)
        {
            playerMoveR.onGround = collision.transform.CompareTag("Floor");

        }


        
    }

}
