using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private Vector3 movement;
	private Rigidbody rigidBody;
	public float speed;

	void Awake()
	{
		//get reference
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		//Fetch Input
		float x = Input.GetAxisRaw ("Horizontal");
		float z = Input.GetAxisRaw ("Vertical");
		movement = new Vector3 (x, 0f, z);

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Plane plane = new Plane (Vector3.up, Vector3.zero);
		float distance;

		if (plane.Raycast (ray, out distance)) 
		{
			Vector3 point = ray.GetPoint (distance);
			Vector3 adjustedHeightPoint = new Vector3 (point.x, transform.position.y, point.z);
			transform.LookAt (adjustedHeightPoint);
		}
	}

	void FixedUpdate()
	{
		//move rigidbody using MovePositon
		Vector3 velocity = movement.normalized * speed * Time.fixedDeltaTime;
		rigidBody.MovePosition(rigidBody.position + velocity);
	}
}
