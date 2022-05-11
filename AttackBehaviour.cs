using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class AttackBehaviour : StateMachineBehaviour
{
    public int damageDeal = 1;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("On Attack Enter " + MainScripController.MyId + " == " + animator.gameObject.GetComponent<NetworkObject>().NetworkObjectId);
        //��� ID == ID ������� ��� �������� ��������
        if (MainScripController.MyId == animator.gameObject.GetComponent<NetworkObject>().NetworkObjectId)
        {
            if (!MainScripController.MyGameObject.TryGetComponent<NavMeshControler>(out NavMeshControler navmeshcontrol))
            {
                return; //�� ����� ��������� NavMeshControler
            }
            //�������� ������� ����������� �����
            MainScripController.MyGameObject.transform.Find("CanvasCamera").gameObject.transform.Find("AtackProgress").gameObject.SetActive(true);
            //������������� ���������
            navmeshcontrol.UpdateTargets(MainScripController.MyGameObject.transform.position);
            //��������� ��� �� ������ ��������
            navmeshcontrol.lockLKMOnly = true;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //��� ID == ID ������� ��� �������� ��������
        if (MainScripController.MyId == animator.gameObject.GetComponent<NetworkObject>().NetworkObjectId) 
        {
            //Debug.Log(animator.gameObject.GetComponent<NetworkObject>().NetworkObjectId + " Exit My atack");
            //Debug.Log(MainScripController.MyGameObject.transform.Find("TargetZone").gameObject.GetComponent<TargetField>().target.name);
            if (MainScripController.MyGameObject.transform.Find("TargetZone").gameObject.GetComponent<TargetField>().target != null) 
            {
                MainScripController.MyGameObject.transform.Find("TargetZone").gameObject.GetComponent<TargetField>().target.GetComponent<�haracteristic>().TakeDamageServerRpc(damageDeal);
            }

            //������ ���
            if (!MainScripController.MyGameObject.TryGetComponent<NavMeshControler>(out NavMeshControler navmeshcontrol))
            {
                return; //�� ����� ��������� NavMeshControler
            }
            //������������ ��� ����� ��������
            navmeshcontrol.lockLKMOnly = false;
            //��������� ������� ����������� �����
            MainScripController.MyGameObject.transform.Find("CanvasCamera").gameObject.transform.Find("AtackProgress").gameObject.SetActive(false);
        }

        //Debug.Log(stateInfo.IsName("Atack1") + " Exit");
        //Debug.Log(animator.gameObject.GetComponent<NetworkObject>().NetworkObjectId);
        //Debug.Log(stateInfo.IsName("Atack1") + " Exit");
        //Debug.Log("On Attack Exit ");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("On Attack Update ");
    }

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("On Attack Move ");
    }

    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("On Attack IK ");
    }
}
