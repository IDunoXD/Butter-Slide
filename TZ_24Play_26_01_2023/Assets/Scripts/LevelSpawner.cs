using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles;
    [SerializeField] GameManager gameManager;
    public bool SpawnPiece=false;
    void Start()
    {
        
    }
    void Update()
    {
        if(SpawnPiece){
            GameObject obj = Instantiate(Obstacles[Random.Range(0,Obstacles.Length)],transform.position,transform.rotation); //spawn ransom level piece
            LevelMove NewPiece = obj.GetComponent<LevelMove>();
            NewPiece.gameManager=gameManager;
            NewPiece.spawner=this;
            NewPiece.enabled=false;
            LevelToPosition ltp = obj.GetComponent<LevelToPosition>();
            ltp.gameManager=gameManager;
            ltp.enabled=true;
            LevelSetup ls = obj.GetComponent<LevelSetup>();
            ls.gameManager=gameManager;
            SpawnPiece=false;
        }
    }
}
