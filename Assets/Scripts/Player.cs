using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Outline outline;

    private Texture2D cursorInteraccion;
    private Texture2D cursorPorDefecto;
    private NavMeshAgent agent;
    private Camera cam;
    private Transform ultimoClick;
    [SerializeField] private float tiempoRotacion;
    private NPC npcActual;
    /// <summary>
    /// private PlayerAnimations playerAnimations;
    /// </summary>

    [SerializeField] private float distanciaInteraccion;
    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        

        if (npcActual)
        {
            if (agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                npcActual.Interactuar(this.transform);
                npcActual = null;
                agent.isStopped = true;
                agent.stoppingDistance = 0;
            }
        }

        if (ultimoClick && ultimoClick.TryGetComponent(out IInteractuable interactuable))
        {
            agent.stoppingDistance = distanciaInteraccion;

            if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                //transform.DOLookAt(npc.transform.position, tiempoRotacion, AxisConstraint.Y).OnComplete( () => LanzarInteraccion(npc));

                LanzarInteraccion(interactuable);
            }
        }
        else if (ultimoClick)
        {
            agent.stoppingDistance = 0f;
        }
        
    }

    

    private void LanzarInteraccion(IInteractuable interactuable)
    {
        
        interactuable.Interactuar(transform);
        ultimoClick = null;
    }

    

    private void Movimiento()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {              
                                              
                           agent.SetDestination(hit.point);
                ultimoClick = hit.transform;    
            }
        }
    }


    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteraccion, Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorPorDefecto, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }

    public void HacerDanho(float danhoataque)
    {
        Debug.Log("HERMANOOOOO" + danhoataque);
    }
}
