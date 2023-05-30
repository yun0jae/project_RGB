           using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNotes : MonoBehaviour
{
    //public GameObject up, down, right, left;
    string key;
    public GameObject[] note;

    private List<GameObject> gameObject = new List<GameObject>();
    private List<GameObject> remove = new List<GameObject> ();

    int selection;
    int count = 0;
    GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        //selection = Random.Range(0, note.Length);

        //GameObject randomNote = note[selection];

        //Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //instance = Instantiate(randomNote, spawnPos, Quaternion.identity);

        //makeList(note, 30);

        //displayNote();


        //Debug.Log(gameObject.Count);
        //foreach(GameObject i in gameObject)
        //{
        //    Debug.Log(i.tag);
        //}\
    }

    // Update is called once per frame
    void Update()
    {

        if (count == 0)
        {
            makeList(note, 30);
            displayNote();
            count++;
            Debug.Log(count);
        }
        key = "";
        if (Input.GetKeyDown(KeyCode.W)) key = "Up";
        else if (Input.GetKeyDown(KeyCode.S)) key = "Down";
        else if (Input.GetKeyDown(KeyCode.A)) key = "Left";
        else if (Input.GetKeyDown(KeyCode.D)) key = "Right";

        //bool keydown = Input.GetKeyDown(KeyCode.Space);
        //if (keydown)
        //{
        //    CreateNt();
        //}

        //if (instance.CompareTag("Down"))
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Up"))
        //{
        //    if (Input.GetKeyDown(KeyCode.W))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Left"))
        //{
        //    if (Input.GetKeyDown(KeyCode.A))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Right"))
        //{
        //    if (Input.GetKeyDown(KeyCode.D))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Down"))
        //{
        //    if (OVRInput.GetDown(OVRInput.Button.One))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Up"))
        //{
        //    if (OVRInput.GetDown(OVRInput.Button.Two))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Left"))
        //{
        //    if (OVRInput.GetDown(OVRInput.Button.Three))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        //if (instance.CompareTag("Right"))
        //{
        //    if (OVRInput.GetDown(OVRInput.Button.Four))
        //    {
        //        Destroy(instance);
        //        selection = Random.Range(0, note.Length);

        //        GameObject randomNote = note[selection];

        //        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        //        instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
        //    }
        //}

        if (remove[0].CompareTag(key))
        {
            removeAll();
            remove.RemoveAt(0);
            Debug.Log(key + "삭제");
            key = "";
            displayNote();

        }


    }

    private Vector3 GetRandomPosition()     
    { 
    
        // Vector3 basePosition = transform.position;

        float posX = Random.Range(-5, 5);
        float posY = Random.Range(-5, 5);
        float posZ = 10;

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    void CreateNt()
    {
        int selection = Random.Range(0, note.Length);

        GameObject randomNote = note[selection];

        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(randomNote, spawnPos, Quaternion.identity);
    }

    

    void RemoveNt()
    {
        CreateNt();
        
    }

    void makeList(GameObject[] a, int n)
    {

        for(int i  = 0;  i < n; i++)
        {
            int rand = Random.Range(0, a.Length);

            GameObject randomNT = a[rand];

            gameObject.Add(randomNT);
        }

         
    }

    void displayNote()
    {

        for (int i = 0; i < gameObject.Count; i++)
        {

            int pY = 5 - (i / 6) * 2;
            int pZ = 10;

            if ((i / 6) % 2  == 0)
            {
                int pX = -5 + (i % 6) * 2;
                Vector3 listPos = new Vector3(pX, pY, pZ);
                remove[i] = Instantiate(gameObject[i], listPos, Quaternion.identity);
            }
            else if((i / 6) % 2 == 1) 
            {
                int pX = 5 - (i % 6) * 2;
                Vector3 listPos = new Vector3(pX, pY, pZ);
                remove[i] = Instantiate(gameObject[i], listPos, Quaternion.identity);
            } 

        }
    }

    void removeAll()
    {
        remove.Clear();
        for (int i = 0; i < remove.Count; i++)
        {
            Destroy(remove[i]);
        }
    }
}
