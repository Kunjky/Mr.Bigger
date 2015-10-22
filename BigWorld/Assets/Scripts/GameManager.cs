using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager Instance{get;private set;}

	void Awake(){
		Instance=this;
	}
	void Start(){

	}

	void UpdateScoreUI(){

	}

}
