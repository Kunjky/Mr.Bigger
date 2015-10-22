using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GroundManager : MonoBehaviour {
	// Singleton
	public static GroundManager Instance{get;private set;}
	// Tham chiếu đến GroundContainer
	public Transform GroundContainer;
	// speed của GroundContainer
	public float groundMoveSpeed;
	// Tạo một mảng chứa cái prefabs ground;
	public GameObject[] grounds;
	// Tạo meột list GameObject
	private List<GameObject> groundList;

	void Awake(){
		Instance=this;
	}

	void Start () {
		groundList=new List<GameObject>();
		// Tạo Object Polling 
		for(int i=0;i<grounds.Length;i++){
			GameObject g = (GameObject)Instantiate(grounds[i]);
			g.SetActive(false);
			g.transform.SetParent(GroundContainer);
			groundList.Add(g);
		}
		InitGround();
		// Set velocity cho GroundContainer
		GroundContainer.GetComponent<Rigidbody>().velocity=Vector3.back*groundMoveSpeed;
	}
	

	void Update () {
	
	}
	void InitGround(){
		groundList[0].SetActive(true);
		groundList[0].transform.position=new Vector3(0,0,0);
		int index=Random.Range(1,2);
		groundList[index].SetActive(true);
		groundList[index].transform.position=new Vector3(0,0,120);
	}

	void CreateGround(Transform pos){
		// Tạo 1 biến random
		int index=(int)Random.Range(0,groundList.Count);
		// Kiểm tra xem có trong Hieranchy chưa?
		if(!groundList[index].activeInHierarchy){
			// Nếu chưa thì active
			groundList[index].SetActive(true);
			groundList[index].transform.position=new Vector3(0,0,pos.position.z+120*2);

		}else{
			// Nếu có rồi thì Random lại
			CreateGround(pos);
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.transform.parent.tag=="OngCong"){
		other.transform.parent.gameObject.SetActive(false);
		CreateGround(other.transform);
		}
	}
}
