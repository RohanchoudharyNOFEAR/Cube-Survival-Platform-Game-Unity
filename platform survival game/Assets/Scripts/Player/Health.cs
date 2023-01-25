using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth = 3;
    [SerializeField]
    private int health;
    public int _Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                health = 0; // force zero as min value
            }
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        health = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //IsplayerDead();
    }

    public void IncreaseHealth()
    {
        if(IsplayerDead() ==false&& health<_maxHealth)
        {
            health++;
        }

    }

    public void DecreaseHealth()
    {
        if (IsplayerDead() == false)
        {
            health--;
        }

    }

    public bool IsplayerDead()
    {
        if (health == 0)
        {
            Debug.Log("player died");
            return true;    
        }
        else return false;
    }



}
