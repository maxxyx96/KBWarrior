using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 30f;
	public int damage; 
	public Rigidbody2D rb;
		
    // Start is called before the first frame update
    void Start()
    {
		//Fly foward
		rb.velocity = transform.right * speed;
		
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo)
	{	
		Debug.Log("This has been hit: " + hitInfo.name);
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			Debug.Log("enemy taken damage: " + damage);
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
