using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TestOnly
{
    [CreateAssetMenu]
    public class Dash : Ability
    {
        public float dashVelocity;

        public override void Activate(GameObject obj)
        {
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            pm.playerLocomotionManager.MovementSpeed = dashVelocity;
        }

        public override void BeginCooldown(GameObject obj)
        {
            PlayerManager pm = obj.GetComponent<PlayerManager>();
            pm.playerLocomotionManager.MovementSpeed = pm.playerLocomotionManager.InitialMovementSpeed;
        }
    }
}
