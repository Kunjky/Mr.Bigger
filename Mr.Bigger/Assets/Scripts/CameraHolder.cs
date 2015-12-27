using UnityEngine;
using System.Collections;

public class CameraHolder : MonoBehaviour {
	public float speedRotate;
	public float speedMove;
	public float smooth;
	Transform m_transform;
	void Awake(){
		m_transform=GetComponent<Transform>();
	}
	
	void Update () {
		m_transform.Translate(Vector3.forward*speedMove*Time.deltaTime);
		m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
			new Vector3(0,0,-Input.GetAxis ("Horizontal")*speedRotate)),Time.deltaTime*smooth);
		//m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
		//	new Vector3(0,0,-Input.acceleration.x*speedRotate)),Time.deltaTime*smooth);
	}
}
