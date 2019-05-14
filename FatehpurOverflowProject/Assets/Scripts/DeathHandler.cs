using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	public GameObject actualSpawnPoint;
	private GameObject player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.transform.position = actualSpawnPoint.transform.position;
		}
	}

	public void PlayerDied()
	{
		player.transform.position = actualSpawnPoint.transform.position;
	}
}
