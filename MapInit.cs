using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInit : MonoBehaviour
{
    //AI Монстров будет брать эти координаты для перемещений
    public int MapMaxXcoord;
    public int MapMaxZcoord;
    public System.Random random = new System.Random(); //Управляет случайными числами, даёт возможность монстрам не выбирать одни и те же числа, т.к. Next делает каждый монстр (а не все одновременно если объявить локально)
    public List<GameObject> SpawnList = new List<GameObject>();

    public void SpawnMonster() 
    {
        for (int i = 0; i < SpawnList.Count; i++)
        {
            SpawnList[i].GetComponent<MonsterSpawnPoint>().enabled = true;
        }
    }
}
