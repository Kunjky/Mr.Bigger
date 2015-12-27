using UnityEngine;
using System.Collections;

public class RotateSample : MonoBehaviour
{	
	void Start(){
		iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(.2f,.2f,.2f),"easeType", "easeOutElastic","time", 1));
	}
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			//iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(.2f,.2f,.2f),"easeType", "easeOutBack","loopType", "loop", "delay", 1));
			iTween.ScaleFrom(this.gameObject,iTween.Hash("scale",new Vector3(0,0,0),"easeType","easeOutBack","time",0.5f));
		}
	}
}

