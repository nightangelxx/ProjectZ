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
        //������������� ���������
        animator.gameObject.transform.GetComponent<MonsterAI>().StopMove();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //��� ����� ����������� � ������ ������� ������� ������� ��� ����
        //������ ��� NetworkID ������� �������������� � animator
        //������ ��� ������ NetworkID ������� ������������ �� ���� ����� � ������� �� ����� ����������� ����
        //Debug.Log("Find target");
        if (StartButtons.isHost == true) 
        {
            if (animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target != null)
            {
                //Debug.Log("My target: " + animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target);
                //Debug.Log("My ID: " + animator.gameObject.transform.GetComponent<NetworkObject>().NetworkObjectId);
                animator.gameObject.transform.Find("TargetZone").GetComponent<TargetField>().target.GetComponent<�haracteristic>().TakeDamageServerRpc(damageDeal);
            }
        }

        //Debug.Log("Follow");
        //��������� ��������� ��������
        animator.gameObject.transform.GetComponent<MonsterAI>().ContinueFollowToAtack();
        
     
    }
}
