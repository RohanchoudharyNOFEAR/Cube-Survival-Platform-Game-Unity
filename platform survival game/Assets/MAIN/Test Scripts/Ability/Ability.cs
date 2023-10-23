using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    public class Ability : ScriptableObject
    {
        public new string name;
        public float cooldownTime;
        public float activeTime;

        public virtual void Activate(GameObject obj)
        {

        }
        public virtual void BeginCooldown(GameObject obj)
        {

        }

    }
}