using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Swap : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerPosition player;
    float GridPosition=0,LeftEdge=-2,RightEdge=2;
    public float swapSpeed=1;
    float A=0,B=0,t=0;
    void Update(){
        player.Pos.x=Mathf.Lerp(A,B,t); //smooth transition in swap motion
        t+=Time.deltaTime*swapSpeed;
    }
    public void SwapMove(InputAction.CallbackContext context){ //respond to input
        if(context.performed && !(gameManager.GameOver || gameManager.GamePause)){
            if(context.ReadValue<Vector2>().x>0 && GridPosition<RightEdge){
                SwapAnimation(0.5f);
            }else if(context.ReadValue<Vector2>().x<0 && LeftEdge<GridPosition){
                SwapAnimation(-0.5f);
            }
        }
    }
    void SwapAnimation(float step){
        A=transform.position.x;
        B=GridPosition+step;
        t=0;
        GridPosition+=step;
    }
}
