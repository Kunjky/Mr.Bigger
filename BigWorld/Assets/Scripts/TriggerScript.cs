using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
	private Transform m_transform;
	public int isLeft;
	void Start(){
		m_transform=transform;
		m_transform.rotation=Quaternion.Euler(new Vector3(m_transform.rotation.x,m_transform.rotation.y,40*isLeft));
	}
	void OnTriggerEnter(Collider other){

		if(other.tag=="Player"){
			iTween.RotateTo(this.gameObject,iTween.Hash("z",-40*isLeft,"easytype",iTween.EaseType.linear,"speed",Random.Range(5,8)));
		}
	}
	void OnTriggerExit(Collider other){
		
		if(other.tag=="Player"){
			iTween.Stop(this.gameObject);
			m_transform.rotation=Quaternion.Euler(new Vector3(m_transform.rotation.x,m_transform.rotation.y,40*isLeft));
		}
	}

}
