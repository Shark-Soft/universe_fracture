using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class health : MonoBehaviour
{

    public float percent = 100;

    public  Image lifeBar;
    void Update()
    {
        percent = Mathf.Clamp(percent, 0, 100);
   if(SceneManager.GetActiveScene().name != "GameOver"){
        lifeBar.fillAmount = percent / 100;
   }
    }
}
