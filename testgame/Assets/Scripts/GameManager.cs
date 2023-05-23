using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove player;
    public GameObject[] stages;

    // Start is called before the first frame update

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();
        stages = new GameObject[2];
        stages[0] = GameObject.Find("WorldB");
        stages[1] = GameObject.Find("WorldR");

        stages[0].SetActive(false);
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
        stages[0].SetActive(true);
        stages[1].SetActive(false);
        player.InitPosition();
    }
}
