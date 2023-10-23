using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        int nextscene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextscene);
    }
    public void ReloadScene()
    {
        Scene curscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curscene.buildIndex);
    }

}
