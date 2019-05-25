﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnGame : MonoBehaviour
{
	public GameObject options;
	private AudioManager audioManager;
	// Start is called before the first frame update
	void Start()
    {
        
    }



	public void continueButton()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			options.SetActive(true);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void MainMenuButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
		audioManager.StopSound("WindDesert");
	}
}
