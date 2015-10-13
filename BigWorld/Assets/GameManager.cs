using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static GameManager Instance{get;private set;}
	public GameObject grounds;
	public float groundMoveSpeed;

	void Awake(){
		Instance=this;
	}
	void Start () {
		grounds.GetComponent<Rigidbody>().velocity=Vector3.back*groundMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void EndGame(){
		grounds.GetComponent<Rigidbody>().velocity=Vector3.zero;
	}
}
