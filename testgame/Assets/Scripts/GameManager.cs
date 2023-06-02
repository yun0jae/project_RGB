using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject[] stages;
    public int currentStage = 0;


    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();

        stages = new GameObject[4];
        stages[0] = GameObject.Find("WorldB");
        stages[1] = GameObject.Find("WorldR");
        stages[2] = GameObject.Find("WorldG");
        stages[3] = GameObject.Find("FinalStage");

        stages[1].SetActive(false);
        stages[2].SetActive(false);
        stages[3].SetActive(false);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoNextStage()
    {
        stages[currentStage].SetActive(false);

        currentStage += 1;
        stages[currentStage].SetActive(true);
    }

}
