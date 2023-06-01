using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audioSource;
    public GameObject player, people, Object, text;
    

    public float playerSpeed = 10.0f;
    public bool manual_ver = false;
    public bool goal = false;
    bool onGround = true;
    bool objectR = false;

    public float time; // 자막 없어지는 타이밍 정하기 위한 변수


    Rigidbody rigid;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        people = GameObject.Find("People");

        Object = GameObject.Find("object"); //SetActive 활용을 위한 보석 오브젝트 호출
        player = GameObject.Find("player"); //player 좌표를 측정하기 위해 오브젝트 호출
        text = GameObject.Find("Text (Legacy)"); //text 컨트롤을 위해 오브젝트 호출
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        people.transform.position = new Vector3(-30, 2, 1); //모델링 때문에 틀어진 좌표 보정
    }

    void FixedUpdate()
    {

        if (gameManager.stages[0].activeSelf)
        {
            bool jumpInput;
            jumpInput = Input.GetButtonDown("Jump");
            if (onGround & jumpInput) rigid.AddForce(Vector3.up * 20, ForceMode.Impulse);
            if (rigid.velocity.y > 0 & rigid.position.y > 15) rigid.AddForce(Vector3.up * (-20), ForceMode.Impulse);
            
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.stages[0].activeSelf)
        {
            if (objectR)
            {
                manual_ver = false;
                people.GetComponent<Animator>().Play("Run"); //쫓아오는 애니메이션 시작
                people.transform.Translate(0, 0, playerSpeed * Time.deltaTime);
               

            }
            if (goal)
            {
                objectR = false;
                manual_ver = true;
                if (Input.GetButtonDown("Fire1")) gameManager.GoNextStage();
                gameObject.GetComponent<EffectScript>().enabled = false;
            }

            time += Time.deltaTime; // 자막 없애는 타이밍 구현
            if (time > 10)
            {
                text.SetActive(false); 
            }
        }

        //Horizontal movement
        int h = (int)Input.GetAxisRaw("Horizontal");

        Vector3 velo = Vector3.zero;
        Vector3 target = new Vector3(transform.position.x,
                                    transform.position.y,
                                    transform.position.z - 5 * h);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, 0.1f);

        //Vertical Movement
        int v = (int)Input.GetAxisRaw("Vertical");
        if (!manual_ver)
        {
            transform.Translate(playerSpeed*(1+v/2) * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(playerSpeed, 0.0f, 0.0f) * Time.deltaTime * v;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("goal"))
        {
            audioSource.Stop();
            goal = true;
            Debug.Log("goal reached!");
        }

        if (gameManager.stages[0].activeSelf)
        {
            if (collision.transform.CompareTag("Object"))
            {
                objectR = true;
                Object.SetActive(false); //오브젝트 획득하면 사라짐
                text.GetComponent<Text>().text = "장애물을 피해서 앞으로 달리세요!"; //텍스트 내용 변경
                audioSource.Play();
                Debug.Log("object gained");
            }

            if (collision.transform.CompareTag("obstacle"))
            {
                Debug.Log(collision.gameObject.name);
            }

            if (collision.transform.CompareTag("Reset"))
            {
                Object.SetActive(true); //게임오버하면 재생성
                text.GetComponent<Text>().text = "보석을 획득하세요!"; //텍스트 원상복구
                InitPosition();
            }

            if (collision.transform.CompareTag("Floor"))
            {
                onGround = true;
            }

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = collision.transform.CompareTag("Floor");
    }


    public void InitPosition()
    {
        transform.position = new Vector3(0.0f, 8.0f, 0.0f);

        if (gameManager.stages[1].activeSelf)
        {
            manual_ver = false;
        }

        if (gameManager.stages[0].activeSelf)
        {
            manual_ver = true;
            goal = false;
            onGround = true;
            objectR = false;
            people.transform.position = new Vector3(-40.0f, 8.0f, 0.0f);
        }

    }
}
