using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float turnSpeed = 4.0f;

	private Vector3 initialOffset;
	private Vector3 offset;


	void Start () {
		offset = transform.position - target.transform.position;
	}

	void LateUpdate() {
		offset = Quaternion.AngleAxis (Input.GetAxis ("CameraHorizontal") * turnSpeed, Vector3.up) * offset;
		transform.position = target.position + offset * target.transform.lossyScale.x; 
		transform.LookAt(target.position);
	}
		
}
