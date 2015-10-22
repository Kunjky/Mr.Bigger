using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MrBiggerScript : MonoBehaviour {
	public static MrBiggerScript Instance{get;private set;}
	[Header("Lượng thức ăn cần để tăng level")]
	public int[] foodNeedToIncreaseLevel;
	[SerializeField]
	[Header("Level hiện tại")]
	private int curSize;
	private int curFoods;
	private int totalFoods;
	private float distance;
	[Header("UI elements")]
	public Text scoreText;
	public Text distanceText;
	public Text foodText;
	public Text SizeText;
	
	private int scoreValue;
	void Start(){
		UpdateUI();
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Food"){
			AddFood();
		}
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="Wall")
			GetComponent<Rigidbody>().velocity=Vector3.up*20;
	}
	void AddFood(){
		totalFoods++;
		if(curSize==foodNeedToIncreaseLevel.Length-1)
			return;
		curFoods++;
		if(curFoods==foodNeedToIncreaseLevel[curSize]){
			curFoods=0;
			if(curSize<foodNeedToIncreaseLevel.Length-1){
				curSize++;
				IncreaseSize(curSize);
			}
		}
		UpdateUI();
	}
	void IncreaseSize(int level){
		transform.localScale+=Vector3.one*0.2f*level;
	}
	public void UpdateUI(){
		foodText.text="Food:"+curFoods+"/"+foodNeedToIncreaseLevel[curSize];
		SizeText.text="Size:"+curSize;
		distanceText.text="";
	}
}
