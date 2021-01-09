using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{	
	
	//Base Health
	public double health;
	public double basehealth = 30;
	public int count;
	
	//Next enemy
	public GameObject enemy;
	public Text text;
	
	public void start()
	{
		text = GetComponent<Text>();
	}
	
	public void TakeDamage (int damage)
	{
		health -= damage; 
		Debug.Log("Damage dealt, health left: " + health);
		if (health <= 0)
		{
			text.text = "New Enemy Spawned!";
			Die();
		}
		else 
		{
			text.text = "Enemy " + count + "'s HP: " + health.ToString();
		}
	}
	
	void Die()
	{
		count = count + 1;
		health = basehealth * 2;
		basehealth = health;
		Instantiate(enemy);
		Destroy(gameObject);
	}
}
