using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {
	public int number;
	private Image img;
	void Start () {
		DontDestroyOnLoad(this.gameObject.transform.parent.gameObject);
		img=GetComponent<Image>();
		img.fillOrigin=Random.Range(0,4);
	}
	
	public void SelfDestroy(){
		Destroy(this.gameObject.transform.parent.gameObject);
	}
	public void SelectScene(){
		Application.LoadLevel(number);
	}
}
