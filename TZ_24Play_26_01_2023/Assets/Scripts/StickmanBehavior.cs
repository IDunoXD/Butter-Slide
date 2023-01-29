using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StickmanBehavior : MonoBehaviour
{
    Rigidbody[] rb;
    Animator animator;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform CollisionChecker;
    [SerializeField] LayerMask mask;
    [SerializeField] Rigidbody Body2Hit;
    bool ragdollTrigger;
    void Start()
    {
        rb = transform.GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        SwitchState(true);
        ragdollTrigger=true;
    }
    void FixedUpdate()
    {
        if(gameManager.GamePause || gameManager.GamePause) return;
        //check for main cube collisions
        if(Physics.Raycast(CollisionChecker.position+Vector3.right*0.25f,Vector3.forward,0.9f,mask) || Physics.Raycast(CollisionChecker.position+Vector3.left*0.25f,Vector3.forward,0.9f,mask)){
            if(!gameManager.GameOver){
                gameManager.GameOver=true;
            }
        }
        if(gameManager.GameOver){
            if(ragdollTrigger){
                SwitchState(false);
                ragdollTrigger=false;
            }
        }else{
            if(!ragdollTrigger){
                SwitchState(true);
                ragdollTrigger=true;
            }
        }
    }
    public void SwitchState(bool state){ //true = alive, false = dead
        foreach (var item in rb)
        {
            item.isKinematic=state;
        }
        animator.enabled=state;
        if(!state)
            Body2Hit.AddForce(Vector3.forward*gameManager.LevelSpeed*3,ForceMode.VelocityChange);
    }
    void OnDrawGizmos(){
        Debug.DrawRay(CollisionChecker.position+Vector3.right*0.25f,Vector3.forward*0.9f,Color.red);
        Debug.DrawRay(CollisionChecker.position+Vector3.left*0.25f,Vector3.forward*0.9f,Color.red);
    }
    void OnTriggerEnter(Collider other){ //gameover if stickman hit obstacle
        if(mask==(mask|1<<other.gameObject.layer))
            gameManager.GameOver=true;
    }
}
