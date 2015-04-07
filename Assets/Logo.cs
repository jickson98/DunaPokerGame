using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Application.platform == RuntimePlatform.IPhonePlayer){
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,true);
		}else if(Application.platform == RuntimePlatform.Android){
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,true);
		}else {
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,false);
		}
		StartCoroutine(drawLogo());
	}
	private IEnumerator drawLogo(){
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel ("2.LobbyTexasPokerClub");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
