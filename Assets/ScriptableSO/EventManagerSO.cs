using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event manager")]
public class EventManagerSO : MonoBehaviour
{
    public event Action OnNuevaMision;
    public void NuevaMision()
    {
        OnNuevaMision.Invoke();
    }
}
