using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    public class AbilityHolder : MonoBehaviour
    {
        public Ability ability;
        float cooldownTime;
        float activeTime;

        enum AbilityState
        {
            ready,
            active,
            cooldown
        }

        private void OnEnable()
        {
            Collectable.OnCollectableAbilityCollodeAction += updateCollisionBoolClientRpc;
        }

        private void OnDisable()
        {
            Collectable.OnCollectableAbilityCollodeAction -= updateCollisionBoolClientRpc;
        }

        AbilityState state = AbilityState.ready;

       public bool collidedWithAbility = false;
        private void Update()
        {
            switch (state)
            {
                case AbilityState.ready:
                    if (collidedWithAbility == true)
                    {
                        collidedWithAbility = false;
                        ability.Activate(gameObject);
                        state = AbilityState.active;
                        activeTime = ability.activeTime;
                    }

                    break;
                case AbilityState.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.BeginCooldown(gameObject);
                        state = AbilityState.cooldown;
                        cooldownTime = Time.deltaTime;
                    }

                    break;
                case AbilityState.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = AbilityState.ready;
                    }
                    break;

            }
        }

        [ClientRpc]
        void updateCollisionBoolClientRpc(ClientRpcParams clientRpcParams = default)
        {
            collidedWithAbility = true;
        }
    }

}