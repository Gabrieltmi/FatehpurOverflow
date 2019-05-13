using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{

	public int sceneToLoad;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				SceneManager.LoadScene(sceneToLoad);
			}
		}
	}
}
