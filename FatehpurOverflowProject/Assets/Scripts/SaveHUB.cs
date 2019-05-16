using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHUB : MonoBehaviour
{
	private GameObject player;
	public GameObject spawn;

	private void Awake()
	{
		player = GameObject.Find("Player");
		if(PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if(PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				player.transform.position = spawn.transform.position;
			}
		}

	}



}
