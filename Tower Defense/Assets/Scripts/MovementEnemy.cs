using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Enemy))]
public class MovementEnemy : MonoBehaviour {

	private Transform target;
	private int wavepointIndex = 0;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Points.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.Speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			NextPoint();
		}

		enemy.Speed = enemy.StartSpeed;
	}

	void NextPoint()
	{
		if (wavepointIndex >= Points.points.Length - 1)
		{
			EndWay();
			return;
		}

		wavepointIndex++;
		target = Points.points[wavepointIndex];
	}

	void EndWay()
	{
		Player.Lives--;
		Spawn.EnemiesAlive--;
		Destroy(gameObject);
	}

}
