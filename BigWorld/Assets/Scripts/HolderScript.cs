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
			
			m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
				new Vector3(0,0,-Input.GetAxis ("Horizontal")*speedRotate)),Time.deltaTime*smooth);
			if(isCamera)
				m_transform.position=Vector3.Lerp(m_transform.position,new Vector3(-Input.GetAxis ("Horizontal")*0.5f,m_transform.position.y,m_transform.position.z),Time.deltaTime);
			//m_transform.rotation=Quaternion.Lerp(m_transform.rotation,Quaternion.Euler(
			//	new Vector3(0,0,Mathf.Clamp(-Input.acceleration.x*speedRotate*2,-speedRotate,speedRotate))),Time.deltaTime*smooth);
		}
		/*if(!rotating){
			if(Input.GetKey(KeyCode.LeftArrow)){
				StartCoroutine(IERotatingL());
			}
			if(Input.GetKey(KeyCode.RightArrow)){
				StartCoroutine(IERotatingR());
			}
		}*/
	}
	/*IEnumerator IERotatingL(){
		rotating=true;
		iTween.RotateAdd(this.gameObject,iTween.Hash("z",60f,"easetype",iTween.EaseType.easeOutQuad,"time",0.5f));
		yield return new WaitForSeconds(0.6f);
		rotating=false;
	}
	IEnumerator IERotatingR(){
		rotating=true;
		iTween.RotateAdd(this.gameObject,iTween.Hash("z",-60f,"easetype",iTween.EaseType.easeOutQuad,"time",0.5f));
		yield return new WaitForSeconds(0.6f);
		rotating=false;
	}*/
	
}