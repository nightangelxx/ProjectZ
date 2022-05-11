using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInit : MonoBehaviour
{
    //AI �������� ����� ����� ��� ���������� ��� �����������
    public int MapMaxXcoord;
    public int MapMaxZcoord;
    public System.Random random = new System.Random(); //��������� ���������� �������, ��� ����������� �������� �� �������� ���� � �� �� �����, �.�. Next ������ ������ ������ (� �� ��� ������������ ���� �������� ��������)
    public List<GameObject> SpawnList = new List<GameObject>();

    public void SpawnMonster() 
    {
        for (int i = 0; i < SpawnList.Count; i++)
        {
            SpawnList[i].GetComponent<MonsterSpawnPoint>().enabled = true;
        }
    }
}
