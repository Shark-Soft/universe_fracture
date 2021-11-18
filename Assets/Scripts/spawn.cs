using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
   public Transform[] spawnpoint;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnear", 6, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

   void spawnear(){
       int i = Random.Range(0,1);
       Instantiate(portal, spawnpoint[i].position, transform.rotation);
   }
}
