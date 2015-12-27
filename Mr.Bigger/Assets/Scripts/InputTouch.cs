using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InputTouch : MonoBehaviour,IPointerDownHandler {
	public static InputTouch Instance{get;private set;}
	private float direction;
	private float value;
	void Awake(){
		Instance=this;
	}
	void Start(){
		direction=-1;
		value=0;
	}
	public void OnPointerDown (PointerEventData data) {
		//Khi người chơi touch vào thi đổi hướng
		direction=direction*(-1);
		value=0;
	}
	public float GetDirection(){
		//smooth value
		value=Mathf.Lerp(value,direction,Time.deltaTime);
		//Trả về 1 rẻ Phải, trả về -1 rẻ Trái
		return value;
	}
		
}
