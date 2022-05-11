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
            //������� ���� ��� ��� �����, �� �������� ����������� ��������� ��
            this.GetComponent<NavMeshControler>().enabled = true;
            //���������� ������ �� ID ������ � GO �� ������� �� ������
            MyId = this.GetComponent<NetworkObject>().NetworkObjectId;
            MyGameObject = this.gameObject;
        }
    }

    void Update()
    {
        
    }
}
