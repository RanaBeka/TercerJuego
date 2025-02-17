using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;

    [SerializeField] private float velocidad;
    [SerializeField] private float danhoataque;
    [SerializeField] private float distancia;
    [SerializeField] private NavMeshAgent agent;
    

    [SerializeField] private Animator anim;
    private Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        main.Combate = this;
        
    }
    private void OnEnable()
    {
        agent.speed = velocidad;
        agent.stoppingDistance = distancia;
    }

    // Update is called once per frame
    void Update()
    {

        if(main.MainTarget!= null && agent.CalculatePath(main.MainTarget.position,new NavMeshPath()))
        {
            EnfocarObjetivo();
            agent.SetDestination(main.MainTarget.position);

            if(!agent.pathPending && agent.remainingDistance<=distancia)
            {
                anim.SetBool("Attack", true);
            }
        }
        else
        {

            main.ActivarPatrulla();
            this.enabled = false;
        }
        
        
    }
    #region Ejecutados por eventos de animación.
    private void Atacar()
    {
        main.MainTarget.GetComponent<Player>().HacerDanho(danhoataque);
    }
    private void FinAtaca()
    {
        anim.SetBool("Attack", false);
    }
    #endregion

    private void EnfocarObjetivo()
    {
        Vector3 direccionATarget = (main.MainTarget.position - this.transform.position).normalized;
        direccionATarget.y = 0;
        Quaternion rotacionATarget = Quaternion.LookRotation(direccionATarget);
        transform.rotation = rotacionATarget;

    }

    
}
