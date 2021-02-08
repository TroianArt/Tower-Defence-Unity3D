using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float StartSpeed = 10f;
	public float Speed;
	public float StartHp = 100;
	public int Worth = 50;
	public GameObject DeathEffect;
	public Image HpBar;

	private float health;
	private bool isDead = false;
	void Start ()
	{
		Speed = StartSpeed;
		health = StartHp;
	}
	public void Damage (float amount)
	{
		health -= amount;
		HpBar.fillAmount = health / StartHp;
		if (health <= 0 && !isDead)
		{
			Die();
		}
	}
	public void Slow (float pct)
	{
		Speed = StartSpeed * (1f - pct);
	}
	void Die ()
	{
		isDead = true;
		Player.Money += Worth;
		GameObject effect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);
		Spawn.EnemiesAlive--;
		Destroy(gameObject);
	}

}
