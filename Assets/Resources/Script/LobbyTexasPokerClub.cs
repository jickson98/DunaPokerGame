using UnityEngine;
using System.Collections;
using System.IO;

public class LobbyTexasPokerClub : MonoBehaviour {

	private string BugString;
	private string urL;
	
	
	public UISlider slider;
	
	public UILabel pName;
	public UILabel ChipMoney;
	public UILabel bigWin;
	public UILabel Level;
	public UILabel career;
	//slider 
	
	public UILabel totalLabel;
	public UILabel secondLabel;
	public UILabel firstLabel;
	public UILabel thirdLabel;
	public UILabel  anteLabel;
	// casino
	public UISlider sliderCasino;
	public UILabel  casainoTotalLabel;
	public UILabel  buyInLabel;
	public UILabel  minBuyInLabel;
	public UILabel  maxBuyInLabel;
	//public UILabel  maxBuyInLabel;
	////	//public UILabel  maxBuyInLabel;
	int players=9;
	int speed=1;
	
	int power;
	int powerTemp;
	float minPower=0.0f;
	float maxPower=60f;
	
	int powerBuyIn;
	int powerTempBuyIn;
	
	float minPowerBuyIn=0.0f;
	float maxPowerBuyIn=100f;
	int tempCasino;
	
	
	
	
	private double[,] betSitNgo=new double[7,5]{
		{0,0,0,0,0},
		{0,1000,4500,2700,1800},
		{0,10000,45000,27000,18000},
		{0,100000,450000,270000,180000},
		{0,1000000,4500000,2700000,1800000},
		{0,10000000,45000000,27000000,18000000},
		{0,100000000,450000000,270000000,180000000}
		
	}; 
	private int selectCasino;
	private float [,] betCasino=new float[7,4]{
		{0,0,0,0},
		{0,100,2000,2000},
		{0,2000,40000,40000},
		{0,40000,800000,800000},
		{0,800000,16000000,16000000},
		{0,16000000,320000000,320000000},
		{0,320000000,6400000000,6400000000}
	}; 
	
	// Use this for initialization
	void Start () {
		
		if (Application.platform == RuntimePlatform.IPhonePlayer){
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,true);
		}else if(Application.platform == RuntimePlatform.Android){
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,true);
		}else {
			Screen.SetResolution(Screen.width,(Screen.width*9)/16,false);
		}
		
		if (!File.Exists (GameManager.instance.pathForDocumentsFile("pokerData.xml"))) {
			GameManager.instance.CreateXML ();
			GameManager.instance.xmlAllDataLoad ();
			StartCoroutine (playerInfo (1));
			GameManager.instance.xmlDataSave(2,0,GameManager.instance.PlayerID);
			BugString = "start()=> CreateXML ()";
		} else {
			GameManager.instance.xmlAllDataLoad ();
			//GameManager.instance.xmlAllDataLoad ();
			//StartCoroutine (playerInfo (3));
			BugString = " CreateXML ()=> have file";
			
		}
		
		
		
		
		
		
		if (Application.systemLanguage == SystemLanguage.Korean) {
			
			GameManager.instance.langs="korean";
		} else if (Application.systemLanguage == SystemLanguage.Chinese) {
			GameManager.instance.langs="Chinese";
		} else if (Application.systemLanguage == SystemLanguage.Arabic) {
			GameManager.instance.langs="Arabic";
		}else if (Application.systemLanguage == SystemLanguage.Chinese) {
			GameManager.instance.langs="Chinese";
		} else if (Application.systemLanguage == SystemLanguage.Russian) {
			GameManager.instance.langs="Russian";
		}else if (Application.systemLanguage == SystemLanguage.Turkish) {
			GameManager.instance.langs="Turkish";
		}else if (Application.systemLanguage == SystemLanguage.Spanish) {
			GameManager.instance.langs="Spanish";
		}else if (Application.systemLanguage == SystemLanguage.Japanese) {
			GameManager.instance.langs="Japanese";
		}else if (Application.systemLanguage == SystemLanguage.French) {
			GameManager.instance.langs="French";
		}else {
			GameManager.instance.langs="English";
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		tempCasino=GameManager.instance.selectCasino;
		power = (int)Mathf.Lerp(minPower,maxPower,slider.sliderValue); //set the sliders min and max values
		
		minPowerBuyIn = betCasino [tempCasino, 1];
		if (GameManager.instance.ChipMoney > betCasino [tempCasino, 2]) {
			maxPowerBuyIn =(float) betCasino [tempCasino, 2];
		} else {
			maxPowerBuyIn=(float)GameManager.instance.ChipMoney;
		}
		
		powerBuyIn = (int)Mathf.Lerp(minPowerBuyIn,maxPowerBuyIn , sliderCasino.sliderValue); //set the sliders min and max values
	}
	
	void OnGUI(){
		int powerTemp = power;
		powerTemp=(int)powerTemp/10+1;
		if (powerTemp > 6) powerTemp = 6;
		//GUI.Label (new Rect (0, 100, 300, 300), "slidervaleu;"+betSitNgo[powerTemp,1].ToString());
		//GUI.Label (new Rect (0, 130, 300, 300), "temp"+powerTemp.ToString());
		
		string.Format ("{0:#,#}",betSitNgo [powerTemp, 2]);
		firstLabel.text = "$"+betSitNgo [powerTemp, 2].ToString("#,#" );
		
		string.Format ("{0:#,#}",betSitNgo [powerTemp, 3]);
		secondLabel.text ="$"+betSitNgo [powerTemp, 3].ToString("#,#" );
		
		string.Format ("{0:#,#}",betSitNgo [powerTemp, 4]);
		thirdLabel.text ="$"+betSitNgo [powerTemp, 4].ToString("#,#" );
		
		
		string.Format ("{0:#,#}",betSitNgo [powerTemp, 1]);
		double temp= betSitNgo [powerTemp, 1]*0.05;
		string.Format ("{0:#,#}",temp);
		anteLabel.text ="$"+betSitNgo [powerTemp, 1].ToString("#,#" )+" + $"+temp.ToString("#,#" );
		
		totalLabel.text="Total: $"+GameManager.instance.ChipMoney.ToString ("#,#");
		
		// select casino
		//double  temppowerBuyIn=powerBuyIn*betCasino[tempCasino, 2]/100;
		float temps=powerBuyIn/10;
		temps = temps * 10;
		string.Format ("{0:#,#}",temps);
		buyInLabel.text="$"+temps.ToString("#,#" );
		
		
		string.Format ("{0:#,#}",minPowerBuyIn);
		
		minBuyInLabel.text="$"+minPowerBuyIn.ToString("#,#" );
		
		
		string.Format ("{0:#,#}", maxPowerBuyIn);
		maxBuyInLabel.text = "$" +maxPowerBuyIn.ToString ("#,#");
		
		
		
		casainoTotalLabel.text="Total: $"+GameManager.instance.ChipMoney.ToString ("#,#");
		
		// status
		pName.text = GameManager.instance.PlayerName.ToString ();
		
		string.Format ("{0:#,#}", GameManager.instance.ChipMoney);
		ChipMoney.text="$"+GameManager.instance.ChipMoney.ToString ("#,#");
		
		string.Format ("{0:#,#}",GameManager.instance.bigWin);
		bigWin.text="$"+GameManager.instance.bigWin.ToString ("#,#");
		
		career.text = GameManager.instance.career.ToString ()+ " Win";
		
		if(GameManager.instance.career>9){
			Level.text="Lv."+GameManager.instance.Level.ToString ();
		}else {
			Level.text="Lv.0"+GameManager.instance.Level.ToString ();
		}
		
		
		
		
	}
	
	private IEnumerator playerInfo(int status){
		
		if (status == 1) {
			urL ="http://www.puzzlers.co.kr/clasicHoldem/PlayerInfo.php?status="+status;
			urL+="&pName="+GameManager.instance.PlayerName;
			urL+="&chips="+GameManager.instance.ChipMoney;
			urL+="&lang="+GameManager.instance.langs;
			//urL+="&gold="+GameManager.instance.Gold;
			//urL+="&money="+GameManager.instance.realMoney;
			
		} else if (status == 2) {
			urL = "http://www.puzzlers.co.kr/clasicHoldem/PlayerInfo.php?status="+status;	
			urL+="&pName="+GameManager.instance.PlayerName;
			urL+="&chips="+GameManager.instance.ChipMoney;
			//urL+="&gold="+GameManager.instance.Gold;
			//urL+="&pID="+GameManager.instance.PlayerID;
			urL+="&money="+0;
		}else if (status == 3) {
			
			urL = "http://www.puzzlers.co.kr/clasicHoldem/PlayerInfo.php?status="+status;
			urL+="&pID="+GameManager.instance.PlayerID;
		}
		
		
		WWW www = new WWW (urL);
		yield return www;
		
		if (!string.IsNullOrEmpty (www.error)) {
			Application.LoadLevel(0);
			Debug.LogError (string.Format ("Fail Whale!\n{0}", www.error));
			yield break; 
		}
		string json = www.text;
		Debug.Log ("wwwtext=" + www.text); 
		
		JSONObject jsdata = new JSONObject (json);
		string result = jsdata.GetField ("result").str;
		if (status == 1) {
			if (result == "success insert") {
				Debug.Log ("success insert playerinfo");
				Debug.Log (result);
				GameManager.instance.PlayerID=jsdata.GetField ("pID").str;
				GameManager.instance.xmlDataSave(2,0, GameManager.instance.PlayerID);
				
			} else {
				Debug.Log (result);
			}
		}else if(status == 2) {
			if (result == "success update") {
				Debug.Log ("success update playerinfo");
				Debug.Log (result);
				
			} else {
				Debug.Log (result);
			}
		}else if(status == 3) {
			if (result == "success select PlayerInfo") {
				GameManager.instance.PlayerName=jsdata.GetField ("pName").str;
				GameManager.instance.PlayerID=jsdata.GetField ("pID").str;
				GameManager.instance.ChipMoney=(double)jsdata.GetField ("chips").n;
				GameManager.instance.Gold=(int)jsdata.GetField ("gold").n;
				GameManager.instance.langs=jsdata.GetField ("lang").str;
				Debug.Log ("success select PlayerInfo");
				Debug.Log (result);
				
			} else {
				Debug.Log (result);
			}
		}
		
	}
}
