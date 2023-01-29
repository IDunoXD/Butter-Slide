using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetup : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        Collectable[] collectables = GetComponentsInChildren<Collectable>();
        foreach(var c in collectables){
            c.gameManager=gameManager;
        }
    }
}
