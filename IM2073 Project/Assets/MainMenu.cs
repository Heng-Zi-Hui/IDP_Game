using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
public void PlayNewGame(){
    
    //reset checkpoint

    SceneManager.LoadScene("1_Play Room");
}

public void Checkpoint(){
    //SceneManager.LoadScene(SceneManager.GetActiveScene(),buildIndex + 1);
}

}
