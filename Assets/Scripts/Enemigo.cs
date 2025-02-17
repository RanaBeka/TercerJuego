using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private SistemaCombate combate;
    private SistemaPatrulla patrulla;

    private Transform mainTarget;
    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform MainTarget { get => mainTarget;  }

    private void Start()
    {
        ActivarPatrulla();
    }
    public void ActivaCombate(Transform target)
    {
        Debug.Log("b");
        mainTarget = target;
        combate.enabled = true;
    }

    public void ActivarPatrulla()
    {
        Debug.Log("c");
        patrulla.enabled = true;
    }
}
