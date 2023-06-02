using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{

    string key;
    public GameObject[] note;

    private List<GameObject> Obj = new List<GameObject>();
    private List<GameObject> remove = new List<GameObject>();

    int selection = 1;
    int count = 0;

    bool isDelay = false;
    float delayTime = 1.0f;
    float accuTime;


    bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        makeList(selection);
        //for(int i = 0; i < Obj.Count; i++)
        //{
        //    Debug.Log(Obj[i].tag);
        //}

        displayNote();
    }

    // Update is called once per frame
    void Update()
    {
        if(count < 30)
        {
            key = "Untagged";

            if (Input.GetKeyDown(KeyCode.W)) { key = "Up"; Debug.Log(key); }
            else if (Input.GetKeyDown(KeyCode.S)) { key = "Down"; Debug.Log(key); }
            else if (Input.GetKeyDown(KeyCode.A)) { key = "Left"; Debug.Log(key); }
            else if (Input.GetKeyDown(KeyCode.D)) { key = "Right"; Debug.Log(key); }// 키 바꾸기

            //if (OVRInput.GetDown(OVRInput.Button.One)) { key = "Up"; Debug.Log(key); }
            //else if (OVRInput.GetDown(OVRInput.Button.Two)) { key = "Down"; Debug.Log(key); }
            //else if (OVRInput.GetDown(OVRInput.Button.Three)) { key = "Left"; Debug.Log(key); }
            //else if (OVRInput.GetDown(OVRInput.Button.Four)) { key = "Right"; Debug.Log(key); }// 키 바꾸기

            if (key != "Untagged")
            {
                if (!isDelay)
                {
                    if (Obj[0].CompareTag(key))
                    {
                        for (int i = 0; i < Obj.Count; i++)
                        {
                            Destroy(Obj[i]);
                        }
                        Obj.RemoveAt(0);
                        displayNote();
                    }
                    else
                    {
                        Debug.Log("Wrong Key!");
                        isDelay = true;
                        TriggerVibration(40, 2, 255);
                    }
                }
            }

            if (isDelay)
            {
                accuTime += Time.deltaTime;
                Debug.Log("올라가는 중");
                if (accuTime >= delayTime)
                {
                    Debug.Log("초기화");
                    accuTime = 0.0f;
                    isDelay = false;
                }
            }

            if (Obj.Count < 1)
            {
                    makeList(selection);
                    displayNote();
                    count++; // count가 30이 되면 게임 클리어 화면으로 넘어가게 하고 싶음 !
            }

        } else
        {
            // 게임 클리어 보석 나와야함
            clear = true;
        }


        

    }

    void makeList(int n) // 오브젝트 리스트 만들기
    {
        for (int i = 0; i < n; i++)
        {
            int rand = Random.Range(0, note.Length);

            GameObject randomNT = note[rand];

            Obj.Add(randomNT);
        }
    }

    void displayNote() // 화면 표시하기
    {

        for (int i = 0; i < Obj.Count; i++)
        {
            float pX = Random.Range(67, 73);
            float pY = Random.Range(100, 105);
            float pZ = Random.Range(0, -9);
            Vector3 listPos = new Vector3(pX, pY, pZ);
            Obj[i] = Instantiate(Obj[i], listPos, Quaternion.Euler(-90,0,0));

            //if ((i / 6) % 2 == 0)
            //{
            //    int pX = -5 + (i % 6) * 2;
            //    Vector3 listPos = new Vector3(pX, pY, pZ);
            //    Obj[i] = Instantiate(Obj[i], listPos, Quaternion.identity);
            //}
            //else if ((i / 6) % 2 == 1)
            //{
            //    int pX = 5 - (i % 6) * 2;
            //    Vector3 listPos = new Vector3(pX, pY, pZ);
            //    Obj[i] = Instantiate(Obj[i], listPos, Quaternion.identity);
            //}

        }
    }


    void keycode()
    {
        key = "Untagged";

        if (Input.GetKeyDown(KeyCode.W)) { key = "Up"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.S)) { key = "Down"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.A)) { key = "Left"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.D)) { key = "Right"; Debug.Log(key); }// 키 바꾸기
    }

    public void TriggerVibration(int iteration, int frequency, int strength)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for(int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        OVRHaptics.LeftChannel.Preempt(clip);
        OVRHaptics.RightChannel.Preempt(clip);
    }
}
