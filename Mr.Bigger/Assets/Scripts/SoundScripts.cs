using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SoundScripts : MonoBehaviour {
	public Text soundText;
	public AudioSource m_audio;
	private bool isSoundOn;
	void Start () {
		float temp=PlayerPrefs.GetFloat("Sound",0.8f);
		m_audio.volume=temp;
		if(temp==0.8f){
			isSoundOn=true;
			soundText.text="Sound:On";
		}
		else{
			isSoundOn=false;
			soundText.text="Sound:Off";
		}
	}
	public void SoundButton(){
		if(isSoundOn){
			isSoundOn=false;
			PlayerPrefs.SetFloat("Sound",0);
			soundText.text="Sound:Off";
			m_audio.volume=PlayerPrefs.GetFloat("Sound");
		}else{
			isSoundOn=true;
			PlayerPrefs.SetFloat("Sound",0.8f);
			soundText.text="Sound:On";
			m_audio.volume=PlayerPrefs.GetFloat("Sound");
		}
	}

}
