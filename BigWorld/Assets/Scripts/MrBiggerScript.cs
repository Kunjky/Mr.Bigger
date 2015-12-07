using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MrBiggerScript : MonoBehaviour {
	public static MrBiggerScript Instance{get;private set;}
	[Header("Lượng thức ăn cần để tăng level")]
	//public int[] foodNeedToIncreaseLevel;
	[SerializeField]
	[Header("Level hiện tại")]
	private int curSize;
	private int curFoods;
	private int totalFoods;
	private float distance;
	[Header("UI elements")]
	public Text scoreText;
	public Text distanceText;
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

	}

	void AddFood(){
		totalFoods++;
		UpdateUI();
		/*if(curSize==foodNeedToIncreaseLevel.Length-1)
			return;
		curFoods++;
		if(curFoods==foodNeedToIncreaseLevel[curSize]){
			curFoods=0;
			if(curSize<foodNeedToIncreaseLevel.Length-1){
				curSize++;
				IncreaseSize(curSize);
			}
		}*/
	}
	void IncreaseSize(int level){
		//m_transform.position+=new Vector3(0,0.02f,0);
		iTween.ScaleAdd(this.gameObject,iTween.Hash("amount",new Vector3(0.05f,0.05f,0.05f),"easeType", "easeOutBack","time",1f));
		// Thay đổi góc nhìn Camera
		//mainCam.fieldOfView-=1;
		//mainCam.transform.Translate(new Vector3(0,0.2f,-0.5f));
		//mainCam.transform.Rotate(new Vector3(1,0,0));

	}
	public void UpdateUI(){
		//foodText.text="Food:"+curFoods+"/"+foodNeedToIncreaseLevel[curSize];
		//SizeText.text="Size:"+curSize;
		scoreText.text="Score\n"+totalFoods.ToString();
	}
	IEnumerator IEFpsShow(){
		while(true){
			percent=(int)(curPowerPool*33.333f);
			percentText.text=percent.ToString()+'%';
			powerBar.fillAmount=curPowerPool*0.33333f;
			distanceText.text="fps:"+(Mathf.Floor(1f/Time.deltaTime)).ToString();
			yield return new WaitForSeconds(0.02f);
		}
	}
}
