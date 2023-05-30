using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class WorldRScript : MonoBehaviour
{
    public PlayerMove playerMove;

    GameManager gameManager;
    AudioSource audioSource;
    public GameObject player, people, Object, text;
    Rigidbody rigid;

    public float playerSpeed = 10.0f;

    bool init;
    public bool objectR; // objectR  
    public bool goal; // goal 지점 도달

    public bool manual_ver; // true-수동전, false-자동 전진
    public bool shake; // 화면 흔들림 효과 
    public bool onGround = true; // 지면에 닿아있는지

    public float time; // 자막 없어지는 타이밍 정하기 위한 변수


    // Start is called before the first frame update
    void Start()
    {

        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.Find("Player");

        people = GameObject.Find("People");
        Object = GameObject.Find("object"); //SetActive 활용을 위한 보석 오브젝트 호출
        text = GameObject.Find("Text (Legacy)"); //text 컨트롤을 위해 오브젝트 호출

        rigid = player.GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        InitRound();
    }

    void FixedUpdate()
    {

        bool jumpInput;
        jumpInput = Input.GetButtonDown("Jump");
        if (onGround & jumpInput) rigid.AddForce(Vector3.up * 20, ForceMode.Impulse);
        if (rigid.velocity.y > 0 & rigid.position.y > 15) rigid.AddForce(Vector3.up * (-20), ForceMode.Impulse);

    }

    void Update()
    {

        if (objectR)
        {
            manual_ver = false;

            // followers
            people.GetComponent<Animator>().Play("Run"); //쫓아오는 애니메이션 시작
            people.transform.Translate(0, 0, playerSpeed * Time.deltaTime);
            shake = true;

            if (init)
            {
                Object.SetActive(false); //오브젝트 획득하면 사라짐
                text.GetComponent<Text>().text = "장애물을 피해서 앞으로 달리세요!"; //텍스트 내용 변경
                audioSource.Play();
            }

            init = false;

        }

        if (goal)
        {
            manual_ver = true;
            shake = false;

            if (objectR)
            {
                audioSource.Stop();
            }
            objectR = false;


            if (Input.GetButtonDown("Fire1")) gameManager.GoNextStage();
        }


        time += Time.deltaTime; // 자막 없애는 타이밍 구현
        if (time > 10)
        {
            text.SetActive(false);
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

    }

    public void InitRound()
    {
        player.transform.position = new Vector3(0.0f, 8.0f, 0.0f);
        people.transform.position = new Vector3(-30, 2, 1); //모델링 때문에 틀어진 좌표 보정

        text.GetComponent<Text>().text = "보석을 획득하세요!"; //텍스트 원상복구

        Object.SetActive(true);

        init = true;
        objectR = false;
        goal = false;

        manual_ver = true;
        shake = false;
    }

}
