using UnityEngine;
using System.Collections;

public class CynlinderRotate : MonoBehaviour {
	public float speedRotate;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation=Quaternion.Euler(transform.rotation.x,transform.rotation.y,Input.GetAxis("Horizontal")*10);
		transform.Rotate(transform.rotation.x,transform.rotation.y,Input.GetAxis("Horizontal")*speedRotate);
		//transform.rotation=Quaternion.Euler(transform.rotation.x,transform.rotation.y,Mathf.Clamp(transform.eulerAngles.z,0,150));
	}
}
