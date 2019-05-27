using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
	private GameObject deathFloor;
	public int numberToSetPlayerPrefs;
	public string[] dialogo;
	public Text textDialogo;
	public bool activated;
	public int[] numeroDialogo;
	public int[] timeTexts;
	public bool useOnlyOneTime;
	public MitraMovement callMethods;
	public GameObject spawnHub;
	[SerializeField]
	private bool canCallLevel1;
	[SerializeField]
	private bool canOpenPortal1;
	[SerializeField]
	private bool canGoAfterLevel1;
	[SerializeField]
	private bool canGoMiddle;
	[SerializeField]
	private bool canGoToLevel2;

	private void Awake()
	{
		deathFloor = GameObject.Find("DeathFloor");

	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !activated)
		{
			activated = true;
			StartCoroutine(DialogoChange());
		}
	}

	public IEnumerator DialogoChange()
	{
		for (int i = 0; i < numeroDialogo.Length; i++)
		{
			textDialogo.text = dialogo[numeroDialogo[i]];
			textDialogo.gameObject.SetActive(true);
			if(useOnlyOneTime)
			yield return new WaitForSeconds(timeTexts[0]);
			else
				yield return new WaitForSeconds(timeTexts[i]);
			textDialogo.gameObject.SetActive(false);
		}
		if(canCallLevel1)
		{
			callMethods.canGoToLevel1 =  true;
			PlayerPrefs.SetInt("PlayedTutorial", 1);
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnHub;
		}
		if(canOpenPortal1)
		{
			callMethods.canOpenPortal1 = true;
		}
		if(canGoAfterLevel1)
		{
			callMethods.canGoAfterLevel1 = true;
		}
		if(canGoMiddle)
		{
			callMethods.goMiddle = true;
		}

		if(canGoToLevel2)
		{
			callMethods.canGoToLevel2 = true;
		}
		PlayerPrefs.SetInt("Dialogo" + numberToSetPlayerPrefs, 1);
	}
}
