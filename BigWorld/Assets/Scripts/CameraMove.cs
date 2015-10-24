using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float degrees;
	public Transform player;
	private Transform originRotation;
	private float z;
	void Start(){
		originRotation = transform;
	}
	void Update () {
		z=Input.GetAxis("Horizontal");

	}
	void LateUpdate(){
		//transform.LookAt(player);
		transform.rotation=Quaternion.Lerp(transform.rotation,Quaternion.Euler(
			new Vector3(originRotation.eulerAngles.x,originRotation.eulerAngles.y,z*degrees)),Time.deltaTime*3);

		transform.position=Vector3.Lerp(transform.position,new Vector3(z*1.5f,transform.position.y,transform.position.z),Time.deltaTime*3);
	}
}
