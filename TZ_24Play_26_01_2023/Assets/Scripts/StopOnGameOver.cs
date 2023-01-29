using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnGameOver : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    ParticleSystem ps;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if(gameManager.GameOver) ps.Stop();
        else ps.Play();
        if(gameManager.GamePause) ps.Pause();
    }
}
