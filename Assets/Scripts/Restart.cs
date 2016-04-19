using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene("FirstScene");
		}
	}
}
