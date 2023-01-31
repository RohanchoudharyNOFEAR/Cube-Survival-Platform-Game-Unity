using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioClip intro, loop;
    //the "intro" field is optional. If you don't want a intro for your song, just leave it blank

    void Start() {

        if (intro != null)
        {

           // AudioController.Instance.PlayBGMWithIntro(intro, loop);
        }
        else
        {
           // AudioController.Instance.PlayBGM(loop);
        }
    }
}
