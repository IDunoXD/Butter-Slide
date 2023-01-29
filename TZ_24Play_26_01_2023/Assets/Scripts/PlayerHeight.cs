using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeight : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerPosition player;
    public float fallSpeed=1;
    float A=0,B=0,t=0;
    public float Wait=0; //time sliding obstacle
    void Update(){
        if(gameManager.GameOver || gameManager.GamePause) return;
        if(B!=gameManager.BoxCount) NewHeight(gameManager.BoxCount);
        player.Pos.y=Mathf.Lerp(A,B,t);
        if(Wait<=0)
            t+=Time.deltaTime*fallSpeed;
        else
            Wait-=Time.deltaTime;
    }
    void NewHeight(int height){
        A=transform.position.y;
        if(B>height) Wait=2/gameManager.LevelSpeed; //2 - distance to slide after hitting obstacle
        B=height;
        t=0;
    }
}
