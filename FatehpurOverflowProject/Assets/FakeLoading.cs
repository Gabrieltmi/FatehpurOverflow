using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoading : MonoBehaviour
{
	public int timeToWait;
	private void Awake()
	{
		if (Global.actualLevel > 0 || PlayerPrefs.GetInt("SetSpawnHub") > 0)
		{
			this.gameObject.SetActive(true);
			StartCoroutine(WaitToShowGameplay());
			Global.isPaused = true;
		}
		else this.gameObject.SetActive(false);
	}
	// Start is called before the first frame update
	void Start()
    {
		Debug.Log(Global.actualLevel);
		Debug.Log(PlayerPrefs.GetInt("SetSpawnHub"));
    }

	IEnumerator WaitToShowGameplay()
	{
		yield return new WaitForSeconds(timeToWait);
		this.gameObject.SetActive(false);
		Global.isPaused = false;
	}
}
