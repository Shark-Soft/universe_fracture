using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void GameOver (){
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("GameOver");
    }
    void restart(){

        
    }
}
