using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
    private int min;

    [SerializeField]
    private int seg;

    [SerializeField]
    private Text timertext;

    private float restante;
    private bool enmarcha;

    private void Awake() {
        restante = (min * 60) + seg;
        enmarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enmarcha){
            restante -= Time.deltaTime;
            if(restante < 1){
                enmarcha = true;
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            timertext.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
