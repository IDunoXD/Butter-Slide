using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class RestartGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject restart;
    [SerializeField] TMP_Text score,maxBoxes;
    void Start()
    {

    }
    void Update()
    {
        if(gameManager.GameOver){
            restart.SetActive(true);
            score.text="Score: " + gameManager.Score;
            maxBoxes.text="Max Boxes: " + gameManager.MaxBoxes;
        }
    }
    public void ReStart(){
        if(gameManager.GameOver){
            gameManager.GameOver=false;
            restart.SetActive(false);
            SceneManager.LoadScene("GameScene");
        }
    }
}
