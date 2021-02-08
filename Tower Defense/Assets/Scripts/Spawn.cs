using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

	public static int EnemiesAlive = 0;
	public GroupEnemies[] Groups;
	public Transform SpawnPoint;
	public float TimeBetweenGroup = 5f;
	public GameManager gameManager;

	private int groupIndex = 0;
	private float countdown = 2f;
    void Update ()
	{
        if (GameManager.GameIsOver)
        {
			StopCoroutine("SpawnGroup");
        }
        if (EnemiesAlive > 0)
		{
			return;
		}
		if (groupIndex == Groups.Length && Player.Lives > 0)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}
		if (countdown <= 0f)
		{
			StartCoroutine("SpawnGroup");
			countdown = TimeBetweenGroup;
			return;
		}
		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
	}
	IEnumerator SpawnGroup ()
	{
		Player.Rounds++;
		GroupEnemies wave = Groups[groupIndex];
		EnemiesAlive = wave.Count;
		for (int i = 0; i < wave.Count; i++)
		{
            SpawnEnemy(wave.Enemy);
			yield return new WaitForSeconds(1f / wave.Rate);
		}
		groupIndex++;
	}
	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, SpawnPoint.position, Quaternion.identity);
	}

}
