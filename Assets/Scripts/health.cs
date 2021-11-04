using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    public float percent = 100;

    public  Image lifeBar;
    void Update()
    {
        percent = Mathf.Clamp(percent, 0, 100);

        lifeBar.fillAmount = percent / 100;
    }
}
