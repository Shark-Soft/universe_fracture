using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class logica_red : MonoBehaviourPunCallbacks
{
    public static logica_red instancia;
    // Start is called before the first frame update

    void Awake()
    {
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Estás en línea");
    }
}
