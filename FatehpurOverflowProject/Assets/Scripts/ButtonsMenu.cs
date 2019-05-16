using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenu : MonoBehaviour
{
	public GameObject mainMenu1;
	public GameObject mainMenu2;

	// Start is called before the first frame update

	private void Awake()
	{
		if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if (PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				mainMenu1.SetActive(false);
				mainMenu2.SetActive(true);
			}
		}
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartGame()
	{
		SceneManager.LoadScene("Hub");
	}

	public void StartGameNewGame()
	{
		PlayerPrefs.DeleteKey("PlayedTutorial");
		SceneManager.LoadScene("Hub");
		if (PlayerPrefs.HasKey("ActualQuantityLevel1"))
		{
			PlayerPrefs.DeleteKey("ActualQuantityLevel1");

		}
		if (PlayerPrefs.HasKey("ActualQuantityLevel2"))
		{
			PlayerPrefs.DeleteKey("ActualQuantityLevel2");
		}

		if (PlayerPrefs.HasKey("ActualQuantityLevel3"))
		{
			PlayerPrefs.DeleteKey("ActualQuantityLevel3");
		}
	}

	public void BackButton()
	{
		if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if (PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				mainMenu1.SetActive(false);
				mainMenu2.SetActive(true);
			}
		}

		else
		{
			mainMenu1.SetActive(true);
			mainMenu2.SetActive(false);
		}
	}

	public void ExitGame()
	{
		Application.Quit();
	}

}
