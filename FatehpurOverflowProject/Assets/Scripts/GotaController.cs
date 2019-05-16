using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GotaController : MonoBehaviour
{
	[SerializeField]
	private int maxQuantity;
	public int actualQuantity;
	private TextMeshPro counterDoor;
	public int actualLevel;
	AudioSource audioData;

	private void Awake()
	{
		counterDoor = GameObject.Find("CounterDoor").GetComponent<TextMeshPro>();

	}

	// Start is called before the first frame update
	void Start()
	{
		counterDoor.text = (actualQuantity + " / " + maxQuantity);
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			if(!PlayerPrefs.HasKey("ActualQuantityLevel" + actualLevel))
			{
				PlayerPrefs.SetInt("ActualQuantityLevel" + actualLevel, actualQuantity);
			}

			else
			{
				if(PlayerPrefs.GetInt("ActualQuantityLevel" + actualLevel) < actualQuantity )
				{

					PlayerPrefs.SetInt("ActualQuantityLevel" + actualLevel, actualQuantity);
				}
			}
			SceneManager.LoadScene(1);
			audioData.Play();

		}
	}

	public void UpdateCounterText()
	{
		counterDoor.text = (actualQuantity + " / " + maxQuantity);
	}
}
