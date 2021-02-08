using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject pause;
	public GameObject gameManager;
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Stop();
		}
	}
	public void Stop ()
	{
		pause.SetActive(!pause.activeSelf);
		if (pause.activeSelf)
		{
			Time.timeScale = 0f;
		} 
		else
		{
			Time.timeScale = 1f;
		}
	}
	public void Restart ()	
	{
		Stop();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
