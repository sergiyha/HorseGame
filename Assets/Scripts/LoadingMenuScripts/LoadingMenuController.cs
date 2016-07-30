using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingMenuController : MonoBehaviour {

    AsyncOperation ao;
    public GameObject loadingBar;
    public Slider progBar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadingLevel(string levelNum)
    {
        StartCoroutine(LoadLevelWithProgress(levelNum));
    }


    IEnumerator LoadLevelWithProgress(string levelNum)
    {
        yield return new WaitForSeconds(0.5f);
        loadingBar.SetActive(true);
        yield return new WaitForSeconds(1f);
        
        ao = SceneManager.LoadSceneAsync(levelNum);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            progBar.value = ao.progress;
            if (ao.progress >= 0.9f)
            {
                ao.allowSceneActivation = true;
                
            }
            yield return null;
        }

    } 
}
