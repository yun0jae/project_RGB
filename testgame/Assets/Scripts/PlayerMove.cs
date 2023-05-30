using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using static UnityEngine.GraphicsBuffer;
=======
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
>>>>>>> Stashed changes

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;
<<<<<<< Updated upstream

    //public float maxSpeed;
    public float forwardspeed=3.0f;
    public float RSidespeed = 0.5f;

    float updateTime;
    float coolDown=0.4f;
    int currentlane=2;
=======
    public GameObject player;
    public WorldRScript playerMoveR;
    public WorldBScript playerMoveB;
    public GameObject Object;
>>>>>>> Stashed changes

    Rigidbody rigid;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
<<<<<<< Updated upstream
=======
        player = GameObject.Find("player");

        playerMoveR = GameObject.Find("WorldR").GetComponent<WorldRScript>();
        playerMoveB = GameObject.Find("WorldB").GetComponent<WorldBScript>();

>>>>>>> Stashed changes
    }

    void Start()
    {
<<<<<<< Updated upstream
        rigid = GetComponent<Rigidbody>();
        transform.Translate(this.transform.position.x, 0, 20 - 8 * currentlane);
        updateTime = coolDown;
=======

>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (gameManager.stages[0].activeSelf)
        {
            transform.Translate(forwardspeed * Time.deltaTime, 0, 0);

            int h = (int)Input.GetAxisRaw("Horizontal");
            //transform.Translate(0, 0, -RSidespeed * h);

            Vector3 velo = Vector3.zero;
            Vector3 target = new Vector3(transform.position.x,
                                        transform.position.y,
                                        transform.position.z - 5 * h);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);


        }

        if (gameManager.stages[1].activeSelf)
        {
            //transform.Translate(forwardspeed * Time.deltaTime, 0, 0);
            transform.position += new Vector3(forwardspeed, 0.0f, 0.0f) * Time.deltaTime;

            int h = (int)Input.GetAxisRaw("Horizontal");
            Vector3 velo = Vector3.zero;
            Vector3 target = new Vector3(transform.position.x,
                                        transform.position.y,
                                        transform.position.z - 5 * h);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);

            //transform.Translate(0, 0, -RSidespeed * h);


            if (Input.GetButtonDown("Jump"))
            {
                rigid.AddForce(Vector3.up * 8, ForceMode.Impulse);
            }
=======


    }

    private void OnCollisionEnter(Collision collision)
    {
        // Blue
        if (gameManager.stages[0].activeSelf)
        {
            if (collision.transform.CompareTag("Goal"))
            {
                playerMoveB.goal = true;
                Debug.Log("BLUE goal reached");
            }


        }


        // Red
        if (gameManager.stages[1].activeSelf)
        {
            if (collision.transform.CompareTag("Object"))
            {
                playerMoveR.objectR = true;
                Debug.Log("RED object obtained");
            }

            if (collision.transform.CompareTag("Goal"))
            {
                playerMoveR.goal = true;
                Debug.Log("RED goal reached");
            }

            if (collision.transform.CompareTag("Reset"))
            {
                playerMoveR.InitRoundR();
            }
        }

    }


    private void OnCollisionStay(Collision collision)
    {
        // Blue
        if (gameManager.stages[0].activeSelf)
        {
            playerMoveB.objectB = collision.transform.CompareTag("Object");

>>>>>>> Stashed changes
        }


        // Red
        if (gameManager.stages[1].activeSelf)
        {
            playerMoveR.onGround = collision.transform.CompareTag("Floor");
        }
    }

<<<<<<< Updated upstream
    void LaneMove(int h)
    {
        if (currentlane + h < 1 | currentlane + h > 4) Debug.Log("out");
        else
        {
            currentlane += h;
            float lanepos = 20 - 8 * currentlane;
            Debug.Log("lane is" + currentlane);
            transform.position = new Vector3(this.transform.position.x, this.transform.position.y, lanepos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.transform.CompareTag("goal"))
        {
            gameManager.GoStageB();
        }

    }

    public void InitPosition()
    {
        transform.position = new Vector3(0.0f, 2.0f, 4.0f);
    }
=======
>>>>>>> Stashed changes
}
