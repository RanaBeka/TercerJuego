using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EjecutarAtaque()
    {
        anim.SetBool("attacking", true);
    }
    public void PararAtaque()
    {
        anim.SetBool("attacking", false);
    }
}
