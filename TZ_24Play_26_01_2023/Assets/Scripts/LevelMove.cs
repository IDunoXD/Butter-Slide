using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    public GameManager gameManager;
    public LevelSpawner spawner;
    bool spawned=false;
    public float DisappearAt=-30; //distance where level piece will disappear
    public float TriggerSpawnAt=0;
    void FixedUpdate()
    {
        if(gameManager.GameOver || gameManager.GamePause) return;
        if(transform.position.z<TriggerSpawnAt && !spawned){
            spawner.SpawnPiece=true;
            spawned=true;
        }
        if(transform.position.z<DisappearAt){
            Destroy(transform.gameObject);
            return;
        }
        transform.position+=Vector3.back*gameManager.LevelSpeed*Time.deltaTime;
    }
}
