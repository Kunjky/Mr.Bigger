using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	public float speed;
	void Start(){
		GetComponent<Rigidbody>().angularVelocity=Vector3.forward*speed;
	}

}
