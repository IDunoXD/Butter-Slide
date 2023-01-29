using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//puts spawned level piece at the end of a road
public class LevelToPosition : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 Pos1, Pos2 = new Vector3(0,-30,90), Pos3 = new Vector3(0,0,90);
    public bool transition1=true, transition2=false;
    public float PieceLength = 30;
    float TransitionTime, t;
    RaycastHit hit;
    void Start(){
        Pos1=transform.position;
    }
    void FixedUpdate()
    {
        if(gameManager.GameOver || gameManager.GamePause) return;
        TransitionTime=PieceLength/gameManager.LevelSpeed;
        if(transition1){ //move to below end position
            transform.position=Vector3.Lerp(Pos1,Pos2,t);
            t+=Time.deltaTime/TransitionTime*2;
            if(t>=1){
                transform.position=Pos2;
                transition1=false;
                transition2=true;
                t=0;
            }
            return;
        }
        if(transition2){ //move up to end position
            transform.position=Vector3.Lerp(Pos2,Pos3,t);
            t+=Time.deltaTime/TransitionTime*2;
            if(t>=1){
                transform.position=Pos3;
                if(Physics.Raycast(transform.position+Vector3.down,Vector3.back,out hit,PieceLength/2)){ //if piece isn't perfectly attached, fix its position
                    transform.position+=Vector3.back*(hit.distance+(gameManager.LevelSpeed*Time.deltaTime));
                }
                transition2=false;
                GetComponent<LevelMove>().enabled=true;
                t=0;
            }
            Debug.DrawRay(transform.position+Vector3.down,Vector3.back*PieceLength/2);
        }
    }
}
