using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weapon : MonoBehaviour
{
	// refgerence to firepoint
	public Transform FirePoint;
	public GameObject bulletPrefab;
	public GameObject powerbulletPrefab;
	public GameObject megabulletPrefab;
	public GameObject bombPrefab;
	public GameObject censorPrefab;
	
	public AudioSource sound;
	public AudioSource bomb;
	public AudioSource baby;
	public AudioSource censor;
	public Text gt;
	public int damage;
	public int totalDamage;
	public int TextLength;	
	public int totalLength = 0;
	
		void start () 
	{
		gt = GetComponent<Text>();
		sound = GetComponent<AudioSource>();
		bomb = GetComponent<AudioSource>();
		baby = GetComponent<AudioSource>();
		censor = GetComponent<AudioSource>();
	}
	
    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (gt.text.Length != 0)
                {
                    gt.text = gt.text.Substring(0, gt.text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r')) // enter/return
            {
				Debug.Log(gt.text.Length);
				TextLength = gt.text.Length;
				Shoot();
				totalLength += TextLength;
				gt.text = "";

            }
            else
            {
				Debug.Log(gt.text);
                gt.text += c;
            }
        }
	}
	
	void Shoot()
	{
		//Shooting Logic
		if (gt.text.ToLower() == "bomb") 
		{
			Instantiate(bombPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength * 12;
			bombPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			bomb.Play();
		}
		else if (gt.text.ToLower() == "fuck" || gt.text.ToLower() == "pussy" || gt.text.ToLower() == "suck" || gt.text.ToLower() == "shit" ) 
		{
			Instantiate(censorPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength * 1;
			censorPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			censor.Play();
		}
		else if (TextLength < 10)
		{
			Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength * 5;
			bulletPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			sound.Play();
		}
		else if (TextLength >= 10 && TextLength < 28) 
		{
			Instantiate(powerbulletPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength*3;
			powerbulletPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			sound.Play();
		}
		else if (TextLength >= 28) 
		{
			Instantiate(megabulletPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength*2;
			megabulletPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			baby.Play();
		}
		else 
		{
			Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
			damage = TextLength;
			bulletPrefab.GetComponent<Bullet>().damage = damage;
			Debug.Log("Dmg = " + damage);
			totalDamage += damage;
			sound.Play();
		}
	}
}
