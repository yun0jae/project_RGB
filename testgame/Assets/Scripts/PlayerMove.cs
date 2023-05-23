using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    GameManager gameManager;

    //public float maxSpeed;
    public float forwardspeed=3.0f;
    public float RSidespeed = 0.5f;

    float updateTime;
    float coolDown=0.4f;
    int currentlane=2;

    Rigidbody rigid;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        transform.Translate(this.transform.position.x, 0, 20 - 8 * currentlane);
        updateTime = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
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
        }

    }

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
}
