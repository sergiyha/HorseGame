using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwicher : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	public void LoadScene (string sceneName) {
        StartCoroutine(loading(sceneName));
        
	}
    //
    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator loading (string sceneName)
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(sceneName);
    }
}
