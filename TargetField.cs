using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetField : MonoBehaviour
{
    public Collider col;
    public GameObject target;
    public bool playerTarget; //возможность брать игроков в цель ИЛИ
    public bool monsterTarget; //возможность брать монстров в цель
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("PLAYER Enter: "+col.gameObject.name);
        //Разрешаем брать в таргет только Игроков и Монстров
        if (playerTarget == true) 
        {
            if (col.gameObject.tag == "isPlayer")
            {
                target = col.gameObject;
            }
        }

        if (monsterTarget == true)
        {
            if (col.gameObject.tag == "isMonster")
            {
                target = col.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        // Destroy everything that leaves the trigger
        //Debug.Log("PLAYER Exit: " + col.gameObject.name);
        if (playerTarget == true)
        {
            if (col.gameObject.tag == "isPlayer")
            {
                target = null;
            }
        }

        if (monsterTarget == true)
        {
            if (col.gameObject.tag == "isMonster")
            {
                target = null;
            }
        }
    }
}
