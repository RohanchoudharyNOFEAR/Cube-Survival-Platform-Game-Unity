using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
   

    public delegate void EnemyCollideAction(Collision other);
 
    public static event EnemyCollideAction OnCollidedEnemyEvent;
    public static event EnemyCollideAction OnColliderExitEvent;
    public Transform CollidedEnemeyTransform;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
          
            Debug.Log("collision detected");
            if (OnCollidedEnemyEvent != null)//very important
            {
                OnCollidedEnemyEvent(collision);
            
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("collision ended");
            if (OnColliderExitEvent != null)//very important
            {
                OnColliderExitEvent(collision);
            }
        }
    }




}
