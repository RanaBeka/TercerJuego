using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{

    [SerializeField] private Enemigo main;

    [SerializeField] private float velocidad;
    [SerializeField] private float distancia;
    [SerializeField] private NavMeshAgent agent;
    private Transform target;
    // Start is called before the first frame update
    private void Awake()
    {
        main.Combate = this;
        agent = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        agent.speed = velocidad;
        agent.stoppingDistance = distancia;
    }

    // Update is called once per frame
    void Update()
    {
        target = main.MainTarget;
        agent.speed = velocidad;
        agent.SetDestination(target.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
