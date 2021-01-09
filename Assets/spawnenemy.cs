using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour
{
	public Transform SpawnPoint;
	public GameObject Timer;
	public GameObject EnemyPrefab;
	public GameObject Player;
	public double mobHealth = 30.0f;
	public double health;

	void Start()
	{
		Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
		EnemyPrefab.GetComponent<Enemy>().health = mobHealth;
		mobHealth = mobHealth * 1.5; //Multiplier
		Debug.Log("New mob spawning with health = " + mobHealth);
	}

	public void TakeDamage (int damage)
	{
		health -= damage; 
		Debug.Log("Damage dealt, health left: " + health);
		if (health <= 0)
		{
			Die();
		}
	}
	
	void Die()
	{
		Destroy(gameObject);
	}

}
