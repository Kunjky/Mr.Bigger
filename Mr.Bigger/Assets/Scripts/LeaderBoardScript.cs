using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LeaderBoardScript : MonoBehaviour {
	public static LeaderBoardScript Instance{get;private set;}
	public GameObject leaderBoardEntry;
	public Text hightScoreText;
	void Awake(){
		if(Instance==null)
			Instance=this;
		else
			Destroy(this.gameObject);
	}
	void Start(){
		hightScoreText.text="Your best score: "+PlayerPrefs.GetInt("HightScore",0).ToString();
		GetLeaderBoard();
	}

	void GetLeaderBoard() {
		new GameSparks.Api.Requests.LeaderboardDataRequest_highScoreLeaderboard().SetEntryCount(5).Send((response) => {
			int i=0;
			foreach (var entry in response.Data)
			{
				GameObject g = (GameObject)Instantiate(leaderBoardEntry);
				g.transform.SetParent(this.gameObject.transform);
				g.transform.localPosition = new Vector3(0,300-150*i,0);
				g.transform.localScale= Vector3.one;
				g.transform.FindChild("rank").GetComponent<Text>().text ="#" + entry.Rank.ToString();
				g.transform.FindChild("name").GetComponent<Text>().text = entry.UserName.ToString();
				g.transform.FindChild("score").GetComponent<Text>().text = entry.GetNumberValue("score").ToString();

				string facebookId = entry.ExternalIds.GetString("FB");

				if (facebookId != "") {
					StartCoroutine(getFBPicture(g, facebookId));
				}

				Debug.Log(entry.ToString());
				i++;
			}
			Debug.Log(response);
		});
	}

	public IEnumerator getFBPicture(GameObject g, string facebookId) {
		var www = new WWW("http://graph.facebook.com/" + facebookId + "/picture?type=square");
		
		yield return www;
		
		Texture2D tempPic = new Texture2D(25, 25);

		www.LoadImageIntoTexture(tempPic);
		g.transform.FindChild("avatar").GetComponent<RawImage>().texture = tempPic;
	}
}
