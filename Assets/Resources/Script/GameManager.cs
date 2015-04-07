using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class GameManager : MonoBehaviour {


	public string roomName;
	public int roomType ;
	public string PlayerName;
	public string PlayerID;
	public int PhotoNo;
	public int smallBlind;
	public int bigBlind;
	public double chipMoney;
	public int Players;
	public bool speedGame;
	public int selectCasin; 
	public float accessInterval=3.1f; 
	public int selectCasino;
	public bool soundEffect;
	public bool vibrate;
	public string langs;
	public double ChipMoney;
	public int bigWin;
	public int career;
	public int Level;
	public int Gold;
	public int messageFlag;

    static GameManager _instance;

	static public bool isActive { 
		get { 
			return _instance != null; 
		} 
	}
	public void drawText(){
		Debug.Log("text manager");
	}

	public void CreateXML()
	{

		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "yes"));
		
		// Root Node
		XmlNode rootNode = xmlDocument.CreateNode(XmlNodeType.Element, "poker", string.Empty);
		xmlDocument.AppendChild(rootNode);
		
		XmlElement PlayerName = xmlDocument.CreateElement("PlayerName");
		int temp = Random.Range (1, 1000000);
		PlayerName.InnerText = "User"+temp.ToString();
		rootNode.AppendChild(PlayerName);
		
		XmlElement PlayerID = xmlDocument.CreateElement("PlayerID");
		PlayerID.InnerText = "";
		rootNode.AppendChild(PlayerID);
		
		XmlElement ChipMoney = xmlDocument.CreateElement("ChipMoney");
		ChipMoney.InnerText = "30000";
		rootNode.AppendChild(ChipMoney);
		
		XmlElement Gold = xmlDocument.CreateElement("Gold");
		Gold.InnerText = "5";
		rootNode.AppendChild(Gold);
		
		XmlElement HandsPlayed = xmlDocument.CreateElement("HandsPlayed");
		HandsPlayed.InnerText = "0";
		rootNode.AppendChild(HandsPlayed);
		
		XmlElement HandsWin = xmlDocument.CreateElement("HandsWin");
		HandsWin.InnerText = "0";
		rootNode.AppendChild(HandsWin);
		
		XmlElement TopChips = xmlDocument.CreateElement("TopChips");
		TopChips.InnerText = "0";
		rootNode.AppendChild(TopChips);
		
		XmlElement PhotoNo = xmlDocument.CreateElement("PhotoNo");
		PhotoNo.InnerText = "0";
		rootNode.AppendChild(PhotoNo);
		
		
		
		//string filepath = Application.persistentDataPath + @"/Resources/data/tentendata.xml";
		//xmlDocument.Save("c:\\tentendata.xml");
		xmlDocument.Save(pathForDocumentsFile("pokerData.xml"));
	}
	
	public void xmlDataSave(int modeN0,int score, string str)
	{
		XmlDocument doc = new XmlDocument();
		//string filepath = Application.persistentDataPath + @"/Resources/data/tentendata.xml";
		doc.Load(pathForDocumentsFile("pokerData.xml"));
		string modes;
		string tempData="";
		
		if (modeN0 == 1) {
			XmlNode node = doc.SelectSingleNode("/poker/PlayerName");
			if (node != null) {
				node.InnerText =str;
			}
		}else if (modeN0 == 2) {
			XmlNode node = doc.SelectSingleNode("/poker/PlayerID");
			if (node != null) {
				node.InnerText =str;
			}
			
		}else if (modeN0 == 3) {
			XmlNode node = doc.SelectSingleNode("/poker/ChipMoney");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
		}else if (modeN0 == 4) {
			XmlNode node = doc.SelectSingleNode("/poker/Gold");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
		}else if (modeN0 == 5) {
			XmlNode node = doc.SelectSingleNode("/poker/HandsPlayed");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
		}else if (modeN0 == 6) {
			XmlNode node = doc.SelectSingleNode("/poker/HandsWin");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
			
		}else if (modeN0 == 7) {
			XmlNode node = doc.SelectSingleNode("/poker/TopChips");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
		}else if (modeN0 == 8) {
			XmlNode node = doc.SelectSingleNode("/poker/PhotoNo");
			if (node != null) {
				node.InnerText =score.ToString();
			}
			
		}else modes="/poker/PhotoNo";
		
		doc.Save( pathForDocumentsFile("pokerData.xml") );
		
	}
	public void xmlDataLoad(int modeNo)
	{
		XmlDocument doc = new XmlDocument();
		//string filepath = Application.persistentDataPath + @"/Resources/data/tentendata.xml";
		doc.Load(pathForDocumentsFile("pokerData.xml"));
		string modes;
		string levelData;
		if (modeNo == 1) {
			modes="/poker/PlayerName";
		}else if (modeNo == 2) {
			modes="/poker/PlayerID";
		}else if (modeNo == 3) {
			modes="/poker/ChipMoney";
		}else if (modeNo == 4) {
			modes="/poker/Gold";
		}else if (modeNo == 5) {
			modes="/poker/HandsPlayed";
		}else if (modeNo == 6) {
			modes="/poker/HandsWin";
		}else if (modeNo == 7) {
			modes="/poker/TopChips";
		}else if (modeNo == 8) {
			modes="/poker/PhotoNo";
			
		}else modes="/poker/PhotoNo";
		
		XmlNode node = doc.SelectSingleNode(modes);
		if (node != null) {
			//int.TryParse(node.InnerText, out modeHiScore[modeNo]);
			//modeHiScore[modeNo]=node.InnerText;
		}
		//Debug.Log ("Score=" + modeHiScore [modeNo]);
	}
	
	public void xmlAllDataLoad()
	{
		XmlDocument doc = new XmlDocument();
		//string filepath = Application.persistentDataPath + @"/Resources/data/tentendata.xml";
		doc.Load(pathForDocumentsFile("pokerData.xml"));
		
		XmlNode node = doc.SelectSingleNode("/poker/PlayerName");
		GameManager.instance.PlayerName=node.InnerText;
		//Debug.Log(GameManager.instance.PlayerName);
		
		node = doc.SelectSingleNode("/poker/PlayerID");
		GameManager.instance.PlayerID=node.InnerText;
		//Debug.Log(GameManager.instance.PlayerID);
		
		node = doc.SelectSingleNode("/poker/ChipMoney");
		double.TryParse(node.InnerText, out GameManager.instance.ChipMoney);
		//Debug.Log(GameManager.instance.ChipMoney);
		
		//node = doc.SelectSingleNode("/poker/Gold");
		//int.TryParse(node.InnerText, out GameManager.instance.Gold);
		//Debug.Log(GameManager.instance.Gold);
		
		//node = doc.SelectSingleNode("/poker/HandsPlayed");
		//int.TryParse(node.InnerText, out GameManager.instance.HandsPlayed);
		//Debug.Log(GameManager.instance.HandsPlayed);
		
		//node = doc.SelectSingleNode("/poker/HandsWin");
		//int.TryParse(node.InnerText, out GameManager.instance.HandsWin);
		//Debug.Log(GameManager.instance.HandsWin);
		
		//node = doc.SelectSingleNode("/poker/TopChips");
		//int.TryParse(node.InnerText, out GameManager.instance.TopChips);
		//Debug.Log(GameManager.instance.TopChips);
		
		node = doc.SelectSingleNode("/poker/PhotoNo");
		int.TryParse(node.InnerText, out GameManager.instance.PhotoNo);
		//Debug.Log(GameManager.instance.PhotoNo);
		
		
		
		
		
		
		//XmlNodeList xnList = xml.SelectNodes("/poker/*"); //?묎렐???몃뱶
		/*

		foreach (XmlNode xn in xnList)
		{
			string part1 = xn["PlayerName"].InnerText; //?덉닠諛?遺덈윭?ㅺ린
			string part2 = xn["PlayerID"].InnerText; //?덉닠諛?code_name 遺덈윭?ㅺ린
			string part3 = xn["ChipMoney"].InnerText; //?덉닠諛?code_name 遺덈윭?ㅺ린
			string part4 = xn["Gold"].InnerText; //?덉닠諛?code_name 遺덈윭?ㅺ린
			string part5 = xn["HandsPlayed"].InnerText;
			string part6 = xn["HandsWin"].InnerText;
			string part7 = xn["TopChips"].InnerText;
			
			string allText=part1 + " | " + part2 + " | " + part3+ " | " + part4+ " | " + part5;
			Debug.Log(allText);
		}

		string modes;
		string levelData;
		if (modeNo == 4) {
			modes="/tenten/mode4";
		}else if (modeNo == 5) {
			modes="/tenten/mode5";
		}else if (modeNo == 6) {
			modes="/tenten/mode6";
		}else if (modeNo == 7) {
			modes="/tenten/mode7";
		}else if (modeNo == 8) {
			modes="/tenten/mode8";
		}else if (modeNo == 9) {
			modes="/tenten/mode9";
		}else  modes="/tenten/mode5";
		
		XmlNode node = doc.SelectSingleNode(modes);
		if (node != null) {
			levelData=node.InnerText;
			for(int i=0; i<10;i++){
				for(int j=0; j<8;j++){
					gameMode[i,j]=levelData[i*8+j]-48;
				}
			}
			
		}
		*/
		//node.InnerText = "11000000000000000000000000000000000000000000000000000000000000000000000000000000";
		
		//////////////////////////////////////////
		
		
		
		
	}
	
	
	public string pathForDocumentsFile( string filename ) 
	{ 
		
		if (Application.platform == RuntimePlatform.IPhonePlayer){
			string path = Application.dataPath.Substring( 0, Application.dataPath.Length - 5 );
			path = path.Substring( 0, path.LastIndexOf( '/' ) );
			return Path.Combine( Path.Combine( path, "Documents" ), filename );
		}else if(Application.platform == RuntimePlatform.Android){
			string path = Application.persistentDataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) ); 
			return Path.Combine (path, filename);
		}else {
			string path = Application.dataPath; 
			path = path.Substring(0, path.LastIndexOf( '/' ) );
			return Path.Combine (path, filename);
		}
		
	}

	static public GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
				
				if (_instance == null)
				{
					GameObject go = new GameObject("_gamemanager");
					DontDestroyOnLoad(go);
					_instance = go.AddComponent<GameManager>();
				}
			}
			return _instance;
		}
	}
}