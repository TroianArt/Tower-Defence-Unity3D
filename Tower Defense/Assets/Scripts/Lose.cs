using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour {

    public void Restart ()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}


}
