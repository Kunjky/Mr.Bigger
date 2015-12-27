using UnityEngine;
using System.Collections;

public class HolderScript : MonoBehaviour {
	public static HolderScript Instance {get;private set;}
	public float speedRotate;
	public float speedMove;
	public float smooth;
	public bool isCamera;
	public bool rotating;
	Transform m_transform;
	void Awake(){
		Instance=this;
		m_transform=GetComponent<Transform>();
	}
	
	void Update () {

		if(GameManager.Instance.curState==GameManager.GAMESTATE.START){
			m_transform.Translate(Vector3.forward*speedMove*Time.deltaTime);
			//---------PC input
			#if UNITY_STANDALONE_WIN||UNITY_EDITOR
			m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
				new Vector3(0,0,-Input.GetAxis ("Horizontal")*speedRotate)),Time.deltaTime*smooth);
			if(isCamera)
				m_transform.position=Vector3.Lerp(m_transform.position,new Vector3(-Input.GetAxis ("Horizontal")*0.5f,m_transform.position.y,m_transform.position.z),Time.deltaTime);

			//---------Mobile input
			#else
			if(isCamera)
				m_transform.position=Vector3.Lerp(m_transform.position,new Vector3(-Input.acceleration.x*0.5f,m_transform.position.y,m_transform.position.z),Time.deltaTime);
				m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
				new Vector3(0,0,Mathf.Clamp(-Input.acceleration.x*speedRotate*2.5f,-speedRotate,speedRotate))),Time.deltaTime*smooth);
			#endif
		}
	}
}