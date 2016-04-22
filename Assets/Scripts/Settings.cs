using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour{


	void Start () {
#if UNITY_ANDROID
       

        Application.targetFrameRate = 300;

                QualitySettings.vSyncCount = 0; 

                QualitySettings.antiAliasing = 0;

               
                QualitySettings.shadowCascades = 0;
                QualitySettings.shadowDistance = 20;
               

                Screen.sleepTimeout = SleepTimeout.NeverSleep; 
                
                #endif
	
	}

}
