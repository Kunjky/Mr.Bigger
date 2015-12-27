using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MrBiggerScript : MonoBehaviour {
	public static MrBiggerScript Instance{get;private set;}
	[SerializeField]
	private int totalFoods;
	[Header("UI elements")]
	public Text scoreText;
	public Text percentText;
	public GameObject gameOverPanel;
	public Image powerBar;
	public Image whiteScreen;
	
	private int scoreValue;
	// Tham chiếu đến Camera
	private Camera mainCam;

	private Animator animCam;
	private bool isChanging;
	private bool isBiggerSize;
	private float tempScore;
	private float curPowerPool;
	private int percent;
	void Awake(){
		Instance=this;
	}
	void Start(){
		mainCam=Camera.main;
		animCam=mainCam.GetComponent<Animator>();
		isBiggerSize=true;
		UpdateUI();
		StartCoroutine(IEFpsShow());
		curPowerPool=3;
	}
	void Update(){
		if(GameManager.Instance.curState==GameManager.GAMESTATE.START)
			GamePlay();
	}
	void GamePlay(){
		//Input Touch
		for(int i =0;i<Input.touchCount;i++)
		{
		Touch touch = Input.GetTouch(0);
		if(touch.phase==TouchPhase.Ended && touch.tapCount==1)
			StartCoroutine(IEChangeSize());
		}
		//Input KeyBoard
		if(Input.GetKeyDown(KeyCode.UpArrow)&&isChanging==false){
			StartCoroutine(IEChangeSize());
		}
		tempScore+=Time.deltaTime;
		if(tempScore>1)
		{
			tempScore=0;
			AddFood();
		}
		if(!isBiggerSize){
			curPowerPool-=Time.deltaTime;
			if(curPowerPool<0.8f){
				powerBar.color=Color.red;
			}

			if(curPowerPool<0)
				StartCoroutine(IEChangeSize());
		}else{
			curPowerPool+=Time.deltaTime*1.5f;
			if(curPowerPool>0.8f){
				powerBar.color=Color.cyan;
			}
		}
		curPowerPool=Mathf.Clamp(curPowerPool,0,3.01f);
	}
	IEnumerator IEChangeSize(){
		isChanging=true;
		if(isBiggerSize==true){
			animCam.SetBool("isBigger",false);
			iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(-0.7f,-0.7f,-0.7f),"easeType", "easeOutElastic","time",0.8f));
			isBiggerSize=false;
		}
		else{
			animCam.SetBool("isBigger",true);
			iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(0.7f,0.7f,0.7f),"easeType", "easeOutElastic","time",0.8f));
			isBiggerSize=true;
		}
		yield return new WaitForSeconds(0.6f);
		isChanging=false;
	}
	void OnTriggerEnter(Collider other){
		if(other.tag == "Food"){
			AddFood();
		}
		if(other.tag=="Obstacle"&&GameManager.Instance.curState==GameManager.GAMESTATE.START){
			GetComponent<AudioSource>().Play();
			StartCoroutine(IEDie());
			whiteScreen.gameObject.SetActive(true);
			GameManager.Instance.SetGameOver(totalFoods);
		}
	}
	IEnumerator IEDie(){
		iTween.RotateAdd(this.gameObject,new Vector3(-90,0,0),0.5f);
		GetComponentInChildren<Animator>().Stop();
		yield return new WaitForSeconds(0.8f);
		gameOverPanel.SetActive(true);

		new GameSparks.Api.Requests.LogEventRequest_postScore().Set_score((long)totalFoods).Send((response) => {
			if (!response.HasErrors) {
				Debug.Log("Score Posted Successfully...");
			} else {
				Debug.Log("Error Posting Score...");
			}
		});
	}

	void AddFood(){
		totalFoods++;
		UpdateUI();
	}
	void IncreaseSize(int level){
		iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(0.05f,0.05f,0.05f),"easeType", "easeOutBack","time",1f));
	}
	public void UpdateUI(){
		scoreText.text="Score\n"+totalFoods.ToString();
	}
	IEnumerator IEFpsShow(){
		while(true){
			percent=(int)(curPowerPool*33.333f);
			percentText.text=percent.ToString()+'%';
			powerBar.fillAmount=curPowerPool*0.33333f;
			yield return new WaitForSeconds(0.02f);
		}
	}
}
