using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class StartGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject start;
    void Start()
    {

    }
    void Update()
    {
        if(gameManager.GamePause) start.SetActive(true);
    }
    public void Play(){
        if(gameManager.GamePause){
            gameManager.GamePause=false;
            start.SetActive(false);
        }
    }
}
