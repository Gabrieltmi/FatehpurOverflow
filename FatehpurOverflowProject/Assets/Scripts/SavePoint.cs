using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
	private GameObject deathFloor;
	public GameObject SpawnPoint;
	public GameObject Particle;

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

	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = SpawnPoint;

				Particle.SetActive(true);
			}
		}
	}
}
