using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public Vector3 Pos;
    Vector3 BeginPosition;
    void Start(){
        BeginPosition=transform.position;
    }
    void Update()
    {
        transform.position=BeginPosition+Pos;
    }
}
