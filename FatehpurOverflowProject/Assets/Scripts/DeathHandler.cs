using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	public GameObject actualSpawnPoint;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.transform.position = actualSpawnPoint.transform.position;
		}
	}
}
