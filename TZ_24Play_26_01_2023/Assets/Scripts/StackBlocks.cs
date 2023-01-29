using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackBlocks : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform extraCubes, cam;
    [SerializeField] GameObject box;
    [SerializeField] Animator animator;
    [SerializeField] GameObject particle,score;
    [SerializeField] LayerMask mask;
    List<Transform> BlocksToRemove = new List<Transform>();
    RaycastHit hit;
    Vector3 ScoreOffset = new Vector3(0,4,-2);
    void Start()
    {

    }
    void FixedUpdate()
    {
        if(gameManager.AddBox) NewBlock();
        for(int i=0; i<extraCubes.childCount; i++){ //check for blocks collisions
            if(Physics.Raycast(extraCubes.GetChild(i).position+Vector3.right*0.25f+Vector3.up*0.5f,Vector3.forward,out hit,0.9f,mask) || Physics.Raycast(extraCubes.GetChild(i).position+Vector3.left*0.25f+Vector3.up*0.5f,Vector3.forward,out hit,0.9f,mask)){
                BlocksToRemove.Add(extraCubes.GetChild(i));
            }
        }
        foreach(var b in BlocksToRemove){ //get rid of collided blocks
            cam.DOComplete();
            cam.DOShakePosition(0.3f).WaitForKill();
            Handheld.Vibrate();
            b.DOKill();
            b.SetParent(hit.transform.parent);
        }
        gameManager.BoxCount-=BlocksToRemove.Count;
        BlocksToRemove.Clear();
    }
    public void NewBlock(){
        Instantiate(box,transform.position+Vector3.down*(gameManager.BoxCount+1),transform.rotation,extraCubes);
        var p = Instantiate(particle,transform.position+Vector3.up,transform.rotation);
        Destroy(p,1);
        var s = Instantiate(score,transform.position+ScoreOffset,Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y-180,transform.eulerAngles.z));
        s.GetComponent<FakeMovement>().gameManager=gameManager;
        Destroy(s,1);
        gameManager.BoxCount++;
        gameManager.Score++;
        animator.SetTrigger("Jump");
        gameManager.AddBox=false;
    }
}
