using UnityEngine;
using System.Collections;

public class PopOutScript : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if(other.tag!="Ground"){
			iTween.ScaleFrom(other.gameObject,iTween.Hash("scale",new Vector3(0,0,0),"easeType","easeOutBack","time",0.5f));
		}

	}
}
