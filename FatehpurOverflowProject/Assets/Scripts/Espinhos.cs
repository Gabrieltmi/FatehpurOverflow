using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Espinhos : MonoBehaviour
{
	private DeathHandler deathHandler;
	private AudioManager audioManager;
	AudioSource audioData;
	// Start is called before the first frame update
	void Start()
    {
		deathHandler = GameObject.Find("DeathFloor").GetComponent<DeathHandler>();
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		audioData = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			deathHandler.PlayerDied();
		}
	}

	public void PlayTornSound()
	{
		audioData.Play();
	}
}
