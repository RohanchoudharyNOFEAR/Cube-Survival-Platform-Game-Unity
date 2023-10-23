using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetedEnemyData", menuName = "ScriptableObjects/TargEtedEnemy")]
public class TargetedEnemyDataSO :  EnemyDataSO
{
    public bool TargetedMovement = true;
}
