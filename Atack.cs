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
        //�������� ��������� ������������� �������
        ulong localClientId = NetworkManager.Singleton.LocalClientId;

        //NetworkObject playerObject = NetworkSpawnManager.GetPlayerNetworkObject(localClientId);
        //Debug.Log(playerObject.name);

        //Debug.Log("My Local ID: " + NetworkManager.Singleton.LocalClientId);
        //Debug.Log("I See ServerClientId: " + NetworkManager.Singleton.ServerClientId);
        //Debug.Log("I See NetworkInstanceId: " + go.GetComponent<NetworkObject>().NetworkInstanceId);

        //������ ������(networkClient) � ����� ���������������
        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(localClientId, out NetworkClient networkClient))
        {
            return; //�� ����� �������� �������
        }

        //��� ����� �������(networkClient) ������ ��������� �haracteristic
        if (!networkClient.PlayerObject.TryGetComponent<�haracteristic>(out �haracteristic characteristic))
        {
            return; //�� ����� ��������� �haracteristic
        }
        */
        //���������� �� ������, ������ ���� �� ��������������
        //characteristic.TakeDamageServerRpc(damage);

        ToAtack.GetComponent<�haracteristic>().TakeDamageServerRpc(damage);
    }
}
