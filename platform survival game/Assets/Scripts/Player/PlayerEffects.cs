using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerEffects : MonoBehaviour
{
    public static PlayerEffects Instance;

    private void Awake()
    {
        makeInstance();
    }

    private void OnDisable()
    {
        Instance = null;
    }

    void makeInstance()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtEffect()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void CancleHurtEffect()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }



}
