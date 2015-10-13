using UnityEngine;
using System.Collections;

public class MrBiggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.transform.parent.tag=="Wall"){
			GameManager.Instance.EndGame();
		}
	}
}
