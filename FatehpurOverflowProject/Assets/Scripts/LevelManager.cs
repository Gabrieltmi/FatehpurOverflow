using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private AudioManager audioManager;
	// Start is called before the first frame update
	private void Awake()
	{
		
	}


	void Start()
    {
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		audioManager.PlaySound("WindDesert");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
