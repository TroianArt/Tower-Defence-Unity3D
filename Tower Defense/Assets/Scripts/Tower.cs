using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	public float Range = 15f;
	public GameObject Bullet;
	public float Rate = 1f;
	public string EnemyTag = "Enemy";
	public Transform PartToRotate;
	public float TurnSpeed = 10f;
	public Transform FirePoint;
	//laser
	public bool HasLaser = false;
	public int DamageLaser = 30;
	public float Slow = .5f;
	public LineRenderer LineRend;
	public ParticleSystem ImpactEffect;
	public Light ImpactLight;

	private float fireCountdown = 0f;
	private Transform target;
	private Enemy targetEnemy;

	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= Range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}

	}

	void Update () {
		if (target == null)
		{
			if (HasLaser)
			{
				if (LineRend.enabled)
				{
					LineRend.enabled = false;
					ImpactEffect.Stop();
					ImpactLight.enabled = false;
				}
			}

			return;
		}

		LookOnTarget();

		if (HasLaser)
		{
			Laser();
		} else
		{
			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / Rate;
			}

			fireCountdown -= Time.deltaTime;
		}

	}

	void LookOnTarget ()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
		PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Laser ()
	{
		targetEnemy.Damage(DamageLaser * Time.deltaTime);
		targetEnemy.Slow(Slow);

		if (!LineRend.enabled)
		{
			LineRend.enabled = true;
			ImpactEffect.Play();
			ImpactLight.enabled = true;
		}

		LineRend.SetPosition(0, FirePoint.position);
		LineRend.SetPosition(1, target.position);

		Vector3 dir = FirePoint.position - target.position;

		ImpactEffect.transform.position = target.position + dir.normalized;

		ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
	}

	void Shoot ()
	{
        GameObject bulletGO = (GameObject)Instantiate(this.Bullet, FirePoint.position, FirePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, Range);
	}
}
