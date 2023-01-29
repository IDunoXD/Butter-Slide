using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject main;
    public GameManager gameManager;
    void OnTriggerEnter(Collider other){
        gameManager.AddBox=true;
        Destroy(main);
    }
}
