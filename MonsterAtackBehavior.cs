using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelloWorld;

public class MonsterAtackBehavior : StateMachineBehaviour
{
    public int damageDeal = 1;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("Stoped");
        //Останавливаем персонажа
        animator.gameObject.transform.GetComponent<MonsterAI>().StopMove();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Эта штука срабатывает у любого монстра поэтому сравним две вещи
        //Первая это NetworkID монстра прикрепленного к animator
        //Вторая это поищем NetworkID монстра отталкиваясь от зоны атаки в которую мы будем прописывать урон
        //Debug.Log("Find target");
        if (StartButtons.isHost == true) 
        {
            if (animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target != null)
            {
                //Debug.Log("My target: " + animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target);
                //Debug.Log("My ID: " + animator.gameObject.transform.GetComponent<NetworkObject>().NetworkObjectId);
                animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target.GetComponent<Сharacteristic>().TakeDamageServerRpc(damageDeal);
            }
        }

        //Debug.Log("Follow");
        //Разрешаем персонажу двигатся
        animator.gameObject.transform.GetComponent<MonsterAI>().ContinueFollowToAtack();
        
     
    }
}
