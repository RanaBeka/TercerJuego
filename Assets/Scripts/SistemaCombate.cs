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
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        agent.speed = velocidad;
        agent.stoppingDistance = distancia;
    }

    // Update is called once per frame
    void Update()
    {
        if(main.MainTarget && agent.CalculatePath(main.MainTarget.position,new NavMeshPath()))
        {
            EnfocarObjetivo();
            agent.SetDestination(main.MainTarget.position);

            if(agent.pathPending && agent.stoppingDistance>=distancia)
            {
                anim.SetBool("Attack", true);
            }
        }
        else
        {
            main.ActivarPatrulla();
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

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
