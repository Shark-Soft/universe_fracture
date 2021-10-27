using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vida : MonoBehaviour
{

    public Image barra;
    public float vida = 100;


    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);

        barra.fillAmount = vida / 100;
    }
}
