using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject trail;
    [SerializeField] PlayerPosition player;
    GameObject[] segments;
    GameObject temp;
    float distance=0;
    int length=20;
    void Start()
    {
        segments = new GameObject[length];
        for(int i=0;i<length;i++){ //initialize trail segments 
            segments[i]=(Instantiate(trail,transform.position,transform.rotation,transform));
            segments[i].GetComponent<FakeMovement>().gameManager=gameManager;
        }
    }
    void Update()
    {
        segments[0].transform.position=new Vector3(player.Pos.x,0,player.Pos.z+10);
        segments[0].transform.LookAt(segments[1].transform);
        distance=Vector3.Distance(segments[0].transform.position,segments[1].transform.position);
        if(distance>0.3f){ //place last segment to beginning
            temp=segments[length-1];
            for(int i=length-1;i>0;i--){
                segments[i]=segments[i-1];
            }
            segments[0]=temp;
        }
    }
}
