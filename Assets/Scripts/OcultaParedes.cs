using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcultaParedes : MonoBehaviour
{

    [SerializeField] private Renderer[] paredes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            foreach(Renderer pared in paredes)
            {
                pared.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Renderer pared in paredes)
            {
                pared.enabled = true;
            }
        }
    }
}
