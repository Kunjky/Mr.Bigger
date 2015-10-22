using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	public Vector3 direction;
	private Transform m_transform;
	void Start(){
		m_transform=transform;
	}
	void Update(){
		m_transform.Rotate(direction*Time.deltaTime);
	}

}
