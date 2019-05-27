using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmirMovement : MonoBehaviour
{
	private GameObject player;
	public float speed;
	public float maxDistToMove;
	public bool isFollowing;
	private GameObject follow;
	public bool canFollowThePlayer;
	public GameObject firstDestination;
	public GameObject portal1Destination;
	public GameObject afterOpenPortal;
	public bool canGoToLevel1;
	public bool canOpenPortal1;
	private bool callOneTime1;
	public GameObject door1;
	private bool returnToPos;
	private Vector3 oldPos;
	public DialogoManager dialogoPortal1;

	private void Awake()
	{
		player = GameObject.Find("Player");
		follow = player.transform.GetChild(0).gameObject;
	}

	// Start is called before the first frame update
	void Start()
    {
		//this.transform.position = follow.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		if (canFollowThePlayer)
		{
			if ((Mathf.Abs((this.transform.position.x + this.transform.position.z) - (follow.transform.position.x + follow.transform.position.z)) > maxDistToMove))
			{
				isFollowing = true;
			}

			if (isFollowing)
			{
				FollowPlayer();
			}

			if ((this.transform.position.x - (follow.transform.position.x)) < 0.1f && (this.transform.position.z - (follow.transform.position.z)) < 0.1f)
			{
				isFollowing = false;
			}
		}

		if(canGoToLevel1)
		{
			GoToLevel1();
		}

		if(canOpenPortal1)
		{
			if (!callOneTime1)
			{
				oldPos = this.transform.position;
				//portal1Destination.transform.GetChild(0).gameObject.SetActive(true);
				door1.GetComponent<DoorHandler>().UnlockyDoor();
				callOneTime1 = true;
				StartCoroutine(ReturnAndText());
			}
			OpenPortal(portal1Destination);
		}

		if(returnToPos)
		{
			ReturnToPos();
		}
	}

	void FollowPlayer()
	{
		transform.position = Vector3.MoveTowards(transform.position, follow.transform.position, speed * Time.deltaTime);
	}

	void GoToLevel1()
	{
		transform.position = Vector3.MoveTowards(transform.position, firstDestination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - firstDestination.transform.position).magnitude < 0.1f)
			canGoToLevel1 = false;
	}
	
	void OpenPortal(GameObject destination)
	{
		transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - destination.transform.position).magnitude < 0.1f)
		{
			canOpenPortal1 = false;
		}
	}

	void ReturnToPos()
	{
		transform.position = Vector3.MoveTowards(transform.position, afterOpenPortal.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - afterOpenPortal.transform.position).magnitude < 0.1f)
		{
			returnToPos = false;
		}
	}

	IEnumerator ReturnAndText()
	{
		yield return new WaitForSeconds(4);
		returnToPos = true;
		yield return new WaitForSeconds(3);
		StartCoroutine(dialogoPortal1.DialogoChange());
	}
}
