using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject ScreenPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
			ChangeStatePause();
		}
	}
	
	public void ChangeStatePause(){
		if(Time.timeScale == 0){
			Time.timeScale = 1;
			ScreenPaused.SetActive(false);
		}else{
			Time.timeScale = 0;
			ScreenPaused.SetActive(true);
		}
	}
}
