using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoManager : MonoBehaviour
{
	public MitraMovement mitraMovement;
	public WaterMovement water;
	private GameObject deathFloor;
	public int numberToSetPlayerPrefs;
	public string[] dialogo;
	public Text textDialogo;
	public bool activated;
	public int[] numeroDialogo;
	public int[] timeTexts;
	public bool useOnlyOneTime;
	public MitraMovement callMethods;
	public GameObject[] spawnAfterLevel;

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
	[SerializeField]
	private bool canGoToLevel3;


	private void Awake()
	{
		deathFloor = GameObject.Find("DeathFloor");
		mitraMovement = GameObject.Find("Mitra").GetComponent<MitraMovement>();
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
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[0];
			mitraMovement.doorNumber = 1;
			PlayerPrefs.SetInt("SetSpawnHub", 1);
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
			StartCoroutine(MoveWater());

		}

		if(canGoToLevel2)
		{
			callMethods.canGoToLevel2 = true;
			mitraMovement.doorNumber = 2;
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[1];
			PlayerPrefs.SetInt("SetSpawnHub", 2);
		}

		if(canGoToLevel3)
		{
			callMethods.canGoToLevel3 = true;
			mitraMovement.doorNumber = 3;
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[2];
			PlayerPrefs.SetInt("SetSpawnHub", 3);
		}
		PlayerPrefs.SetInt("Dialogo" + numberToSetPlayerPrefs, 1);
	}

	IEnumerator MoveWater()
	{
		yield return new WaitForSeconds(2);
		water.canMoveUp = true;
		yield return new WaitForSeconds(12);
		water.canMoveUp = false;
	}
}
