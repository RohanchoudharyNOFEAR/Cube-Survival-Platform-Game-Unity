using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class Enemy : NetworkBehaviour
    {

        //public delegate void EnemyCollideAction(Collision other);
        //public static event EnemyCollideAction OnCollidedEnemyEvent;
        //public static event EnemyCollideAction OnEnemeyColliderExitEvent;

        // Start is called before the first frame update
         public virtual void Start()
        {

        }

        // Update is called once per frame
        public virtual void Update()
        {

        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Player"))
        //    {

        //         Debug.Log("collision detected");
        //        if (OnCollidedEnemyEvent != null)//very important
        //        {
        //            OnCollidedEnemyEvent(collision);

        //        }
        //    }
        //}
        //private void OnCollisionExit(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Player"))
        //    {

        //        Debug.Log("collision ended");
        //        if (OnEnemeyColliderExitEvent != null)//very important
        //        {
        //            OnEnemeyColliderExitEvent(collision);
        //        }
        //    }
        //}

    }
}