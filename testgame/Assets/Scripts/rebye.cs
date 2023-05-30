using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebye : MonoBehaviour
{

    string key;
    public GameObject[] note;

    private List<GameObject> Obj = new List<GameObject>();
    private List<GameObject> remove = new List<GameObject>();

    int selection = 30;
    int count = 0;

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
        key = "Untagged";

        if (Input.GetKeyDown(KeyCode.W)) { key = "Up"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.S)) { key = "Down"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.A)) { key = "Left"; Debug.Log(key); }
        else if (Input.GetKeyDown(KeyCode.D)) { key = "Right"; Debug.Log(key); }// 키 바꾸기

        if (Obj[0].CompareTag(key))
        {
            for(int i = 0; i < Obj.Count; i++)
            {
                Destroy(Obj[i]);
            }
            Obj.RemoveAt(0);
            displayNote();
        }

        if(Obj.Count < 1)
        {
            if(count < 2)
            {
                makeList(selection);
                displayNote();
                count++; // count 가 2가 되면 게임 클리어 화면으로 넘어가게 하고 싶음 !
            }
            
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

            int pY = 5 - (i / 6) * 2;
            int pZ = 10;

            if ((i / 6) % 2 == 0)
            {
                int pX = -5 + (i % 6) * 2;
                Vector3 listPos = new Vector3(pX, pY, pZ);
                Obj[i] = Instantiate(Obj[i], listPos, Quaternion.identity);
            }
            else if ((i / 6) % 2 == 1)
            {
                int pX = 5 - (i % 6) * 2;
                Vector3 listPos = new Vector3(pX, pY, pZ);
                Obj[i] = Instantiate(Obj[i], listPos, Quaternion.identity);
            }

        }
    }

}
