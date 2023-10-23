using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestOnly
{
    [System.Serializable]
    public class ClientData
    {
        public ulong clientId;
        public int characterId = -1;

        public ClientData(ulong clientid)
        {
            clientId = clientid;
        }
    }

}
