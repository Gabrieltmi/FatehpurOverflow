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
	public TextMeshPro counterDoor;

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
			SceneManager.LoadScene(1);
		}
	}

	public void UpdateCounterText()
	{
		counterDoor.text = (actualQuantity + " / " + maxQuantity);
	}
}
