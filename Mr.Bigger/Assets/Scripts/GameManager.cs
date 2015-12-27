using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	public static GameManager Instance{get;private set;}
	public enum GAMESTATE{
		MENU,
		START,
		GAMEOVER
	}
	public GAMESTATE curState;
	public Image gameOverPanel;
	public Button shareButton;
	public Button replayButton;
	public Text gameOverText;
	public Text yourScoreText;
	public Text scoreText;
	private int curScore;
	private AudioSource m_audio;
	void Awake(){
		Instance=this;
	}
	void Start(){
		m_audio=GetComponent<AudioSource>();
		curState=GAMESTATE.START;
		m_audio.volume=PlayerPrefs.GetFloat("Sound",0.8f);
	}
	public void SetGameOver(int score){
		curState=GAMESTATE.GAMEOVER;
		curScore=score;
		if(curScore>PlayerPrefs.GetInt("HightScore",0)){
			PlayerPrefs.SetInt("HightScore",curScore);
		}
		StartCoroutine(UIAnimation());
		StartCoroutine(IESoundPitchDown());
	}

	IEnumerator IESoundPitchDown(){
		while(m_audio.pitch>0){
			m_audio.pitch-=0.025f;
			yield return new WaitForSeconds(0.1f);
		}
	}
	IEnumerator UIAnimation(){
		yield return new WaitForSeconds(1f);
		while(gameOverPanel.fillAmount<1){
			gameOverPanel.fillAmount+=0.05f;
			yield return new WaitForSeconds(0.01f);
		}
		gameOverText.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		yourScoreText.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		int deltaScore=0;
		while(deltaScore<=curScore){
			scoreText.text=deltaScore.ToString();
			deltaScore++;
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds(0.2f);
		iTween.ScaleAdd(shareButton.gameObject,iTween.Hash("amount",new Vector3(0.4f,0.4f,0),"easytype",iTween.EaseType.easeOutBack,"time",0.5f));
		yield return new WaitForSeconds(0.2f);
		iTween.ScaleAdd(replayButton.gameObject,iTween.Hash("amount",new Vector3(0.4f,0.4f,0),"easytype",iTween.EaseType.easeOutBack,"time",0.5f));
	}

}
