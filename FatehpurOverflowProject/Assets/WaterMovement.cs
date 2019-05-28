using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
	public float[] posY;
	public float speed;
	public bool canMoveUp;
	public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMoveUp)
		{
			MoveUp();
		}
    }

	void MoveUp()
	{
		if(level == 1)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,posY[1],transform.position.z), speed * Time.deltaTime);
		}

		else if(level == 2)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posY[2], transform.position.z), speed * Time.deltaTime);
		}

		else if(level == 3)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posY[3], transform.position.z), speed * Time.deltaTime);
		}
	}

}
