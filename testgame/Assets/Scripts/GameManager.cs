using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject[] stages;


    //public PlayerMoveR playerR;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
<<<<<<< Updated upstream
        stages = new GameObject[2];
        stages[0] = GameObject.Find("WorldB");
        stages[1] = GameObject.Find("WorldR");

        stages[0].SetActive(false);
=======

        stages = new GameObject[4];
        stages[0] = GameObject.Find("WorldB");
        stages[1] = GameObject.Find("WorldR");
        stages[2] = GameObject.Find("WorldG");
        stages[3] = GameObject.Find("FinalStage");

        stages[1].SetActive(false);
        stages[2].SetActive(false);
        stages[3].SetActive(false);

>>>>>>> Stashed changes
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoStageB()
    {
<<<<<<< Updated upstream
        stages[0].SetActive(true);
        stages[1].SetActive(false);
        player.InitPosition();
=======
        stages[currentStage].SetActive(false);

        currentStage += 1;
        stages[currentStage].SetActive(true);
>>>>>>> Stashed changes
    }
}
