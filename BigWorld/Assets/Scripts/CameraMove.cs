using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float degrees;
	public Transform player;
	private Transform originRotation;
	void Start(){
		originRotation = transform;
	}
	void Update () {
		float z =Input.GetAxis("Horizontal");
		transform.LookAt(player);
		transform.rotation=Quaternion.Euler(new Vector3(originRotation.eulerAngles.x,originRotation.eulerAngles.y,z*degrees));
		transform.position=new Vector3(z,transform.position.y,transform.position.z);
	}
}
