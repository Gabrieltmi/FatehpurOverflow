using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveHUB : MonoBehaviour
{
	private GameObject player;
	public GameObject spawn;
	[SerializeField]
	private TextMeshPro level1Counter;
	[SerializeField]
	private TextMeshPro level2Counter;
	[SerializeField]
	private TextMeshPro level3Counter;
	[SerializeField]
	private GameObject thanksMenu;
	public GameObject options;
	private AudioManager audioManager;
	[SerializeField]
	private GameObject[] dialogo;



	private void Awake()
	{
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		player = GameObject.Find("Player");
		if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if (PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				player.transform.position = spawn.transform.position;
			}
		}

		if (PlayerPrefs.HasKey("ActualQuantityLevel1"))
		{
			level1Counter.text = (PlayerPrefs.GetInt("ActualQuantityLevel1").ToString() + "/ 21");
		}

		if (PlayerPrefs.HasKey("ActualQuantityLevel2"))
		{
			level2Counter.text = (PlayerPrefs.GetInt("ActualQuantityLevel2").ToString() + "/ 13");

		}

		if (PlayerPrefs.HasKey("ActualQuantityLevel3"))
		{
			level3Counter.text = (PlayerPrefs.GetInt("ActualQuantityLevel3").ToString() + "/ 23");
		}

		for (int i = 0; i < dialogo.Length; i++)
		{
			if (PlayerPrefs.HasKey("Dialogo" + i))
			{
				dialogo[i].SetActive(false);
			}
		}

		if (Global.actualLevel == 1)
		{
			dialogo[4].SetActive(true);
			dialogo[5].SetActive(true);
			dialogo[6].SetActive(true);
			dialogo[7].SetActive(true);
		}
		if(Global.actualLevel == 2)
		{
			dialogo[8].SetActive(true);
			dialogo[9].SetActive(true);
		}
	
	}

	private void Start()
	{
		if (PlayerPrefs.HasKey("ActualQuantityLevel3"))
		{
			thanksMenu.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
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
