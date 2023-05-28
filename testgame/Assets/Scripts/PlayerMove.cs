using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;
    public GameObject people;

    public float playerSpeed = 10.0f;
    public bool manual_ver = false;
    public bool goal = false;
    bool onGround = true;
    bool objectR = false;


    Rigidbody rigid;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        people = GameObject.Find("People");
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
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
                people.transform.Translate(0, 0, playerSpeed * Time.deltaTime);

            }
            if (goal)
            {
                objectR = false;
                manual_ver = true;
                if (Input.GetButtonDown("Fire1")) gameManager.GoNextStage();
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
            goal = true;
            Debug.Log("goal reached!");
        }

        if (gameManager.stages[0].activeSelf)
        {
            if (collision.transform.CompareTag("Object"))
            {
                objectR = true;
                Debug.Log("object gained");
            }

            if (collision.transform.CompareTag("obstacle"))
            {
                Debug.Log(collision.gameObject.name);
            }

            if (collision.transform.CompareTag("Reset"))
            {
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
