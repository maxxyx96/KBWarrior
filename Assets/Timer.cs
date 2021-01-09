using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	//Timer 
	public float timeLeft;
	bool game = false;
	//Reference to player
	public GameObject player;

	//Update text
	public Text timertext;
	public Text guidetext;
	
	void start()
	{
		timertext = GetComponent<Text>();
		guidetext = GetComponent<Text>();
	}
	
    // Update is called once per frame
    void Update()
    {
        foreach (char c in Input.inputString)
        {
			if ((c == '\n') || (c == '\r'))
			{
				if (game == false)
				{
					timeLeft = 20f;
				}
				game = true;
			}
		}	
		if (game == false) 
		{
			timertext.text = "20secs to type/spam your way to victory! Press Enter to send the message!";
			guidetext.text = "Press enter to start!";
		}
		else
		{
			guidetext.text = "";
			timertext.text = "Time Left: " + Mathf.Round(timeLeft);
			if (timeLeft <= 0)
			{
				timeLeft = 0;
				timertext.text = "Time Up? I won by alot! Tweeted " + player.GetComponent<weapon>().totalLength*3 + " Characters Per Minute! dealt " + player.GetComponent<weapon>().totalDamage + " Damage!";				
				guidetext.text = "Press F5 to restart. (sorry first time coding a unity game :P)";
			}
			else
			{
				timeLeft -= Time.deltaTime;
			}
		}
    }
}
