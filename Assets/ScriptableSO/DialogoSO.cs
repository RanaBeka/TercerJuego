using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogo")] 
public class DialogoSO : ScriptableObject
{
    [TextArea]
    public string[] frases;
    public AudioClip[] frasesClip;
    public float tiempoEntreLetras;
    public bool tieneMision;
    public string textoMision;
    
    
}