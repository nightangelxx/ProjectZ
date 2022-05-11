using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MLAPI;
using UnityEngine.UI;

public class NavMeshControler : NetworkBehaviour
{

    private GameObject CamGO;
    private Camera Cam;
    public NavMeshAgent navAgents;
    public Animator Animator;
    //==========================
    public GameObject targetGO;
    public float atackspeed = 1.0f;
    public float rotatespeed = 3f;
    public bool atack;
    //==========================
    //public GameObject atackProgess;
    //==========================
    public bool canMove = true;
    //==========================
    public bool lockController = false;
    public bool lockLKMOnly = false;
    public bool lockPKMOnly = false;
    //public float velocity;
    //public Transform targetMarker;

    private void Start()
    {
        CamGO = GameObject.FindGameObjectWithTag("MainCamera");

        if (IsLocalPlayer) 
        {
            //находим камеру, добавляем тэги для работы с ней
            Cam = CamGO.GetComponent<Camera>();
            CamGO.GetComponent<Camera>().enabled = true;
            //просим камеру следовать за мной
            CamGO.GetComponent<CameraMove>().enabled = true;
            CamGO.GetComponent<CameraMove>().target = this.transform;
            //включаем зону считывания атаки, если она моя
            targetGO.SetActive(true);
        }
        //navAgents.destination = targetMarker.position;
    }

    public void UpdateTargets(Vector3 targetPosition)
    {
            navAgents.destination = targetPosition;
    }

    private void Update()
    {
        if (lockController == false) 
        {     
            /*if (Input.GetMouseButton(0)) 
            {
                Debug.Log("Mouse Pressed");  // Not called when player is moving
            }*/
            //velocity = this.GetComponent<NavMeshAgent>().velocity.magnitude / this.GetComponent<NavMeshAgent>().speed;
            //Debug.Log("speed "+ this.GetComponent<NavMeshAgent>().speed);
            if (IsLocalPlayer)
            {
                Animator.SetFloat("speed", (this.GetComponent<NavMeshAgent>().velocity.magnitude));
                //Debug.Log("magnitude " + this.GetComponent<NavMeshAgent>().velocity.magnitude);
            }

            if (lockLKMOnly == false) 
            {
                if (Input.GetMouseButton(0))
                {

                    Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfo;

                    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                    {
                        Vector3 targetPosition = hitInfo.point;
                        UpdateTargets(targetPosition);
                        //targetMarker.position = targetPosition;

                        //Смена оружия быстренько накидал, как-то так
                        //Debug.Log(hitInfo.collider.gameObject.name);
                        if (hitInfo.collider.gameObject.name == "Sword") 
                        {
                            this.GetComponent<WeaponChanger>().ChangeWeapon("Sword");
                        }
                        if (hitInfo.collider.gameObject.name == "Dagger")
                        {
                            this.GetComponent<WeaponChanger>().ChangeWeapon("Dagger");
                        }
                        if (hitInfo.collider.gameObject.name == "Hands")
                        {
                            this.GetComponent<WeaponChanger>().ChangeWeapon("Hands");
                        }
                    }

                }
                else
                {
                    //UpdateTargets(this.gameObject.transform.position);
                }
            }

            if (lockPKMOnly == false)
            {
                if (Input.GetMouseButton(1))
                {
                    Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hitInfo;

                    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                    {
                        Vector3 targetPosition = hitInfo.point;
                        LookAtXZ(targetPosition, rotatespeed);
                    }
                }

                if (Input.GetMouseButtonDown(1))
                {
                    UpdateTargets(this.gameObject.transform.position);
                    //включаем слайдер
                    //atackProgess.SetActive(true);
                    //=====
                    Animator.SetBool("attack", true);
                    //Debug.Log("Down");
                }
                if (Input.GetMouseButtonUp(1))
                {
                    Animator.SetBool("attack", false);
                    //отключаем слайдер
                    //atackProgess.SetActive(false);
                    //Debug.Log("Up");
                }
            }         
            
            //=========================================================
            AnimatorStateInfo animState = Animator.GetCurrentAnimatorStateInfo(0);
            if (Animator.GetCurrentAnimatorStateInfo(0).IsTag("Atack"))
            {
                float currentTime = animState.normalizedTime % 1;
                //Debug.Log(currentTime);
                this.gameObject.transform.Find("CanvasCamera").gameObject.transform.Find("AtackProgress").gameObject.GetComponent<Slider>().value = currentTime;
            }
            //=========================================================
            
        }
    }
    public void LookAtXZ(Vector3 point, float speed)
    {
        var direction = (point - this.transform.position).normalized;
        direction.y = 0f;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.LookRotation(direction), speed);
    }

    /*
    private void OnDrawGizmos()
    {
        Debug.DrawLine(targetMarker.position, targetMarker.position + Vector3.up * 5, Color.red);
    }
    */
}
