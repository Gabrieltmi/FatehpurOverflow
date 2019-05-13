using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
		this.transform.Rotate(Vector3.up, 30 * Time.deltaTime);
    }

	void OnTriggerEnter(Collider col)
	{
		if(col.CompareTag("Player"))
		{
			Destroy(this.gameObject);
		}
	}

}
