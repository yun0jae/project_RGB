using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject[] stages;
    public int currentStage = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        stages = new GameObject[2];
        stages[0] = GameObject.Find("WorldR");
        stages[1] = GameObject.Find("WorldB");
        //stages[2] = GameObject.Find("FinalStage");

        player.InitPosition();
        stages[1].SetActive(false);
        //stages[2].SetActive(false);
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
        player.InitPosition();
    }

}
