using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomEnemyData", menuName = "ScriptableObjects/RandomEnemy")]
public class RandomMovementEnemySO : EnemyDataSO
{
    public bool RandomInstantiateMovement = true;
}
