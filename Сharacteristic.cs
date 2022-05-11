using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HelloWorld;

public class Сharacteristic : NetworkBehaviour
{
    [SerializeField] public Text txt;

    public NetworkVariableInt health = new NetworkVariableInt(100);

    [ServerRpc(RequireOwnership = false)]
    public void TakeDamageServerRpc(int damage)
    {
        //Наносим урон по здоровью
        health.Value = health.Value - damage;
        txt.text = health.Value.ToString();

        //Если ХП меньше нуля, тогда 0
        if (health.Value <= 0)
        {
            health.Value = 0;
            txt.text = health.Value.ToString();
            if (this.gameObject.tag == "isPlayer")
            {
                this.GetComponent<NavMeshControler>().lockController = true;
            }
            if (this.gameObject.tag == "isMonster")
            {
                this.GetComponent<MonsterAI>().Dead();
                if (this.gameObject.GetComponent<MonsterAI>().MonsterName == "Skeleton")
                {
                    if (this.GetComponent<Animator>().GetBool("dead") == false) 
                    {
                        GameObject questLog = GameObject.FindGameObjectWithTag("questLog");
                        questLog.GetComponent<QuestParam>().MonsterCount++;
                        questLog.GetComponent<Text>().text = "Скелет убито " + questLog.GetComponent<QuestParam>().MonsterCount + "\\15";
                    }
                }
            }
            //Умираем
            this.GetComponent<Animator>().SetBool("dead", true);
        }
    }

    private void OnEnable()
    {
        health.OnValueChanged += OnHealthChange;
    }

    private void OnDisable()
    {
        health.OnValueChanged -= OnHealthChange;
    }

    private void OnHealthChange(int oldHealth, int newHealth) 
    {
        if (StartButtons.isClient == true) 
        {
            //Наносим урон по здоровью
            health.Value = newHealth;
            txt.text = newHealth.ToString();

            //Debug.Log("Выполнена клиентская часть");
            Debug.Log("Client - oldHealth: " + oldHealth + " newHealth: " + newHealth);
            if (newHealth <= 0)
            {
                Debug.Log("DEAD");
                newHealth = 0;
                txt.text = newHealth.ToString();
                if (this.gameObject.tag == "isPlayer")
                {
                    this.GetComponent<NavMeshControler>().lockController = true;
                }
                if (this.gameObject.tag == "isMonster")
                {
                    this.GetComponent<MonsterAI>().Dead();
                    if (this.gameObject.GetComponent<MonsterAI>().MonsterName == "Skeleton")
                    {
                        if (this.GetComponent<Animator>().GetBool("dead") == false)
                        {
                            GameObject questLog = GameObject.FindGameObjectWithTag("questLog");
                            questLog.GetComponent<QuestParam>().MonsterCount++;
                            questLog.GetComponent<Text>().text = "Скелет убито " + questLog.GetComponent<QuestParam>().MonsterCount + "\\15";
                        }
                    }
                }
                //Умираем
                this.GetComponent<Animator>().SetBool("dead", true);
            }
        }
    }
}
