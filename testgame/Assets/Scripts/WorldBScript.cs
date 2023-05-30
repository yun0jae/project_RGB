using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldBScript : MonoBehaviour
{

    public PlayerMove playerMove;
    public GameObject player;
    GameManager gameManager;

    public GameObject Object, text;
    Rigidbody rigid;

    public float playerSpeed = 25.0f;

    public bool init;
    public bool moving;
    public bool goal; // goal 지점 도달

    public bool objectB; // objectB grabbed
    public bool manual_ver;

    float time; // 자막 없어지는 타이밍 정하기 위한 변수
    float timelimit=15.0f;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");

        Object = GameObject.Find("object");
        text = GameObject.Find("Text (Legacy)");

        rigid = player.GetComponent<Rigidbody>();

        InitRoundB();
    }

    void Update()
    {
        if (init & Input.GetButtonDown("Fire1"))
        {
            init = false;
            moving = true;

            manual_ver = false;

            text.GetComponent<Text>().text = "장애물을 좌우로 피해서 달리세요!"; //텍스트 내용 변경
            text.SetActive(true);
            timelimit = 3.0f;
            time = 0.0f;
        }

        if (goal)
        {
            manual_ver = true;

            if (moving)
            {
                text.GetComponent<Text>().text = "오브젝트를 left ctrl로 잡아 다음 단계로"; //텍스트 내용 변경
                text.SetActive(true);
                time = 0.0f;
            }
            moving = false;

        }

        
        if (objectB & Input.GetButtonDown("Fire1"))
        {
            gameManager.GoNextStage();
        }


        //Horizontal movement
        int h = (int)Input.GetAxisRaw("Horizontal");

        Vector3 velo = Vector3.zero;
        Vector3 target = new Vector3(player.transform.position.x,
                                    player.transform.position.y,
                                    player.transform.position.z - 5 * h);
        player.transform.position = Vector3.SmoothDamp(player.transform.position, target, ref velo, 0.1f);

        //Vertical Movement
        int v = (int)Input.GetAxisRaw("Vertical");
        if (!manual_ver)
        {
            player.transform.Translate(playerSpeed * (1 + v / 2) * Time.deltaTime, 0, 0);
        }
        else
        {
            player.transform.position += new Vector3(playerSpeed, 0.0f, 0.0f) * Time.deltaTime * v;
        }

        time += Time.deltaTime; // 자막 없애는 타이밍 구현
        if (time>timelimit)
        {
            text.SetActive(false);
        }


    }

    public void InitRoundB()
    {
        player.transform.position = new Vector3(-200.0f, 8.0f, 0.0f);

        text.GetComponent<Text>().text = "left ctrl 키를 눌러 게임을 시작하세요!"; 

        Object.SetActive(true);

        init = true;
        manual_ver = true;
        goal = false;
        objectB = false;
    }
}
