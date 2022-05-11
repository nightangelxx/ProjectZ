using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Connection;
using MLAPI.Spawning;

public class Atack : MonoBehaviour
{
    public GameObject ToAtack;
    public void DealDamage(int damage)
    {
        /*
        //Получаем локальный идентификатор клиента
        ulong localClientId = NetworkManager.Singleton.LocalClientId;

        //NetworkObject playerObject = NetworkSpawnManager.GetPlayerNetworkObject(localClientId);
        //Debug.Log(playerObject.name);

        //Debug.Log("My Local ID: " + NetworkManager.Singleton.LocalClientId);
        //Debug.Log("I See ServerClientId: " + NetworkManager.Singleton.ServerClientId);
        //Debug.Log("I See NetworkInstanceId: " + go.GetComponent<NetworkObject>().NetworkInstanceId);

        //Получи объект(networkClient) с таким идентификатором
        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(localClientId, out NetworkClient networkClient))
        {
            return; //Не нашли сетевого клиента
        }

        //Ддя этого клиента(networkClient) получи компонент Сharacteristic
        if (!networkClient.PlayerObject.TryGetComponent<Сharacteristic>(out Сharacteristic characteristic))
        {
            return; //Не нашли компонент Сharacteristic
        }
        */
        //Отправляем на сервер, нанеси урон по характеристике
        //characteristic.TakeDamageServerRpc(damage);

        ToAtack.GetComponent<Сharacteristic>().TakeDamageServerRpc(damage);
    }
}
