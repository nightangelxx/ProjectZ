using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MLAPI;

public class MainScripController : NetworkBehaviour
{
    public static ulong MyId { get; private set; }
    public static GameObject MyGameObject { get; private set; }
    void Start()
    {
        if (IsLocalPlayer)
        {
            //Смотрим если это мой игрок, то включаем возможность управлять им
            this.GetComponent<NavMeshControler>().enabled = true;
            //Глобальные ссылки на ID игрока и GO за который он играет
            MyId = this.GetComponent<NetworkObject>().NetworkObjectId;
            MyGameObject = this.gameObject;
        }
    }

    void Update()
    {
        
    }
}
