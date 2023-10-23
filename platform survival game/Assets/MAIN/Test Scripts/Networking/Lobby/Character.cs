using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace TestOnly
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Characters/Character")]
    public class Character : ScriptableObject
    {
        [SerializeField] private int id = -1;
        [SerializeField] private string displayName = "New Display Name";
        [SerializeField] private Sprite icon;
        [SerializeField] private GameObject introPrefab;
        [SerializeField] private GameObject gameplayPrefab;

        public int Id => id;
        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public GameObject IntroPrefab => introPrefab;
        public GameObject GameplayPrefab => gameplayPrefab;
    }
}