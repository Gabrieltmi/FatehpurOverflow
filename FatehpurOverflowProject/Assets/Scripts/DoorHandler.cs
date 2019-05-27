using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
	public bool canUse;
	public int sceneToLoad;
	public Material oldMat;
	public Material newMat;
	private bool changeMat;
	[SerializeField]
	private Gradient gradient;
	[SerializeField]
	float duration;
	float t = 0f;

	void Start()
    {
        
    }

    void Update()
    {
		if (changeMat)
		{
			float value = Mathf.Lerp(0f, 1f, t);
			t += Time.deltaTime / duration;
			Color color = gradient.Evaluate(value);
			this.GetComponentInChildren<Renderer>().material.color = color;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.E) && canUse)
			{
				SceneManager.LoadScene(sceneToLoad);
			}
		}
	}

	public void UnlockyDoor()
	{
		canUse = true;
		changeMat = true;
	}

}
