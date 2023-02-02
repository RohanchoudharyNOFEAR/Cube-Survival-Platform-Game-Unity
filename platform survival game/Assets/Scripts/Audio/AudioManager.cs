using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource playerHurtSound;
    public AudioSource playerDieSound;
    public AudioSource TargetedEnemyExplosion;


    private void Awake()
    {
        makeinstance();
    }

    private void OnDisable()
    {
        Instance = null;
    }


    void makeinstance()
    {
        if(Instance!=null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }

    }
   

   public  void playHurtAudio()
    {
        playerHurtSound.Play();
    }

    public void playDieAudio()
    {
        playerDieSound.Play();
    }
    public void TargetedEnemeyExplosionAudio()
    {
        TargetedEnemyExplosion.Play();
    }


}
