using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    public bool GameOver=false,GamePause=false;
    public float LevelSpeed=1;
    public int BoxCount=0,MaxBoxes=0,Score=0;
    public bool AddBox=false;
    void Start()
    {
        
    }
    void Update()
    {
        if(BoxCount>MaxBoxes) MaxBoxes=BoxCount;
    }
}
