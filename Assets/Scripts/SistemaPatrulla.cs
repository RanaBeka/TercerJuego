using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{

    [SerializeField] private Enemigo main;
    [SerializeField] private Transform ruta;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float VelocidadPatrulla;

    [SerializeField] private float distanciaPatrulla;

    List<Vector3> listadoPuntos = new List<Vector3>();

    private Vector3 destinoActual;
    private int indiceRutaActual = -1;
    //private float tiempoEntrePuntos;

    // Start is called before the first frame update

    private void Awake()
    {
        main.Patrulla = this;

        foreach (Transform punto in ruta)
        {
            listadoPuntos.Add(punto.position);
        }
        
    }
    void Start()
    {
        
        


    }

    private void OnEnable()
    {
        indiceRutaActual = -1;
        agent.speed = VelocidadPatrulla;
        agent.stoppingDistance = distanciaPatrulla;
        StartCoroutine(PatrullarYEsperar());
    }
    private IEnumerator PatrullarYEsperar()
    {
        while (true)
        {
            CalcularDestino();
            agent.SetDestination(destinoActual);
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= 0.2f);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
       
        
        //yield return new WaitForSeconds(Random.Range.tiempoEntrePuntos);
    }
    private void CalcularDestino()
    {
        indiceRutaActual++;


        if(indiceRutaActual >= listadoPuntos.Count)
        {
            indiceRutaActual = 0;
        }

        destinoActual = listadoPuntos[indiceRutaActual];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("a");
            StopAllCoroutines();
            main.ActivaCombate(other.transform);
            this.enabled = false;
            
            
        }
    }
}
