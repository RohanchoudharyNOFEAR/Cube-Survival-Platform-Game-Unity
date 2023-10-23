using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
   
    public delegate void EnemyCollideAction(Collision other); 
    public static event EnemyCollideAction OnCollidedEnemyEvent;
    public static event EnemyCollideAction OnEnemeyColliderExitEvent;

    public delegate void ColletableCollideAction();
    public static event ColletableCollideAction OnCollidedCollectableEvent;
    public static event ColletableCollideAction OnCollectableColliderExitEvent;

    public Transform CollidedEnemeyTransform;

   
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
          
           // Debug.Log("collision detected");
            if (OnCollidedEnemyEvent != null)//very important
            {
                OnCollidedEnemyEvent(collision);
            
            }
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {

            Debug.Log("collision detected");
            if (OnCollidedCollectableEvent != null)//very important
            {
                OnCollidedCollectableEvent();

            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("collision ended");
            if (OnEnemeyColliderExitEvent != null)//very important
            {
                OnEnemeyColliderExitEvent(collision);
            }
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {

            Debug.Log("collision detected");
            Destroy(collision.gameObject);
            if (OnCollectableColliderExitEvent != null)//very important
            {
                OnCollectableColliderExitEvent();

            }
        }
    }




}
