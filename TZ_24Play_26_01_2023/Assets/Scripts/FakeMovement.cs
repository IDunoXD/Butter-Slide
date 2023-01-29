using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeMovement : MonoBehaviour
{
    public GameManager gameManager;
    void FixedUpdate()
    {
        if(gameManager.GameOver || gameManager.GamePause) return;
        transform.position+=Vector3.back*gameManager.LevelSpeed*Time.deltaTime;
    }
}
