using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public GameObject SwordGO;
    public GameObject DaggerGO;

    public void ChangeWeapon(string weaponName) 
    {
        switch (weaponName)
        {
            case "Sword":
                SwordGO.SetActive(true);
                DaggerGO.SetActive(false);
                this.gameObject.GetComponent<Animator>().SetBool("hands", false);
                this.gameObject.GetComponent<Animator>().SetBool("dagger", false);
                this.gameObject.GetComponent<Animator>().SetBool("sword", true);
                break;

            case "Dagger":
                DaggerGO.SetActive(true);
                SwordGO.SetActive(false);
                this.gameObject.GetComponent<Animator>().SetBool("hands", false);
                this.gameObject.GetComponent<Animator>().SetBool("sword", false);
                this.gameObject.GetComponent<Animator>().SetBool("dagger", true);
                break;

            default:
                //убрать оружие
                SwordGO.SetActive(false);
                DaggerGO.SetActive(false);
                this.gameObject.GetComponent<Animator>().SetBool("dagger", false);
                this.gameObject.GetComponent<Animator>().SetBool("sword", false);
                this.gameObject.GetComponent<Animator>().SetBool("hands", true);
                break;
        }
    }

}
