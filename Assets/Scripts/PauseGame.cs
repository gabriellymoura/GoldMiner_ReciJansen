using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PauseGame : MonoBehaviour
{
    bool isPause;    

    public void Pause(){
        Time.timeScale = 0;
    }

    public void UnPause(){
        Time.timeScale = 1;
    }

    public void Update(){
        //if(Input.GetKeyDown(KeyCode.P)){
            isPause = !isPause;
            if (isPause){
                Pause();
            } else{
                UnPause();
            }
        //}
    }
}
