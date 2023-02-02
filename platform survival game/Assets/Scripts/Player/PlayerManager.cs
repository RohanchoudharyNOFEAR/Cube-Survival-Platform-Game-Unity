using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Health _playerHealth;



    private void OnEnable()
    {
        PlayerCharacter.OnCollidedEnemyEvent += DealDamage;
        PlayerCharacter.OnColliderExitEvent += StopHurtEffect;
        
    }
    private void OnDisable()
    {
        PlayerCharacter.OnCollidedEnemyEvent -= DealDamage;
        PlayerCharacter.OnColliderExitEvent -= StopHurtEffect;
    }

    void Start()
    {
        _playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        PLayerFallen();
    }


    private void DealDamage(Collision other)
    {
        //play hurt Effect
        PlayerEffects.Instance.HurtEffect();
        AudioManager.Instance.playHurtAudio();
        //health--
        _playerHealth.DecreaseHealth();
        //bounce off effect
        PlayerEffects.Instance.BounceBackEffect(other);
    }

    private void StopHurtEffect(Collision other)
    {
        PlayerEffects.Instance.CancleHurtEffect();
    }

    private void PLayerFallen()
    {
        if (transform.position.y < 0f)
        {
            _playerHealth._Health = 0;
        }
    }



}
