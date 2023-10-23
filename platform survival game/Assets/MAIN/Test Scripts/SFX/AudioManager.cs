using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace TestOnly
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioClip menuAudioClip;
        public AudioClip gamePlayAudioClip;
        public AudioSource playerHurtSound;
        public AudioSource playerDieSound;
        public AudioSource TargetedEnemyExplosion;
        public AudioSource collectedItemsSound;
        public AudioSource MainMenuAudioSource;
        public AudioSource GameplayAudioSource;

        private AudioSource AudioManagerAudioSource;

        private void Awake()
        {
            makeinstance();
           // AudioManagerAudioSource = GetComponent<AudioSource>();
         //   AudioManagerAudioSource.Play();
        }

        private void Update()
        {
            PlayAudioBassedOnScene();
        }

        private void OnDisable()
        {
            //  Instance = null;
        }


        void makeinstance()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }

        }

        bool isPlaying = false;
  private void PlayAudioBassedOnScene()
        {
           
            //if scene is MenuScene
            if (SceneManager.GetActiveScene().buildIndex==0)
            {
                //GameplayAudioSource.Stop();
                //GameplayAudioSource.gameObject.SetActive(false);
                //Debug.Log(SceneManager.GetActiveScene().buildIndex);
                //Debug.Log(isPlaying + "gmeplay");
                //if (isPlaying == true)
                //{ 
                //    Debug.Log(isPlaying + "gmeplay");
                  
                //    isPlaying = false;
                //}

                //MainMenuAudioSource.Play();
            }
            else if(SceneManager.GetActiveScene().buildIndex ==2 )
            {
                GameplayAudioSource.gameObject.SetActive(true);
                if (isPlaying == false)
                {
                    isPlaying = true;
                    Debug.Log(SceneManager.GetActiveScene().buildIndex);
                    MainMenuAudioSource.Stop();
                    GameplayAudioSource.Play();
                   // GameplayAudioSource.PlayOneShot(gamePlayAudioClip);
                   
                    //  GameplayAudioSource.Play();
                }
             
            }
        }


        public void playHurtAudio()
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
        public void CollectableItemCollectedSound()
        {
            collectedItemsSound.Play();
        }
    }
}
