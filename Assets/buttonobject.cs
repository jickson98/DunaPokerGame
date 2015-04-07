using UnityEngine;
using System.Collections;

public class buttonobject : MonoBehaviour {
	public GameObject pop_01buyin; 
	public GameObject pop_02sitngo; 
	public GameObject pop_03selectpicture; 
	public GameObject pop_04selectcasino; 
	
	// Use this for initialization
	void Start () {
		pop_01buyin.SetActive(false); 
		pop_02sitngo.SetActive(false);
		pop_03selectpicture.SetActive(false);
		pop_04selectcasino.SetActive(false);
	}
	void PopUpButton()
	{
		Debug.Log ("button0 call");
		//	pop_01buyin.SetActive(true);
		
	}
	void PopUpButton1()
	{
		GameManager.instance.selectCasino = 1;
		Debug.Log ("button1 call");
		//pop_01buyin.SetActive(true);
		
	}
	void PopUpButton2()
	{
		//GameManager.instance.selectCasino = 2;
		Debug.Log ("button2 call");
		//	pop_01buyin.SetActive(true);
		
	}
	
	void PopUpButton3()
	{
	//	GameManager.instance.selectCasino = 3;
		Debug.Log ("button3 call");
		//	pop_01buyin.SetActive(true);
	}
	void PopUpButton4()
	{
	//	GameManager.instance.selectCasino = 4;
		Debug.Log ("button4 call");
		//	pop_01buyin.SetActive (true);
	}
	
	void PopUpButton5()
	{
		//GameManager.instance.selectCasino = 5;
		Debug.Log ("button5 call");
		//	pop_01buyin.SetActive (true);
	}
	void PopUpButton6()
	{
		//GameManager.instance.selectCasino = 6;
		Debug.Log ("button6 call");
		//	pop_01buyin.SetActive (true);
	}
	
	void PopUpExitButton()
	{
		//	pop_01buyin.SetActive(false);
	}
	void PopUpExitButton2()
	{
		//	pop_02sitngo.SetActive(false);
	}
	
	void PopUpExitButton3()
	{
		//pop_03selectpicture.SetActive(false);
	}
	void PopUpExitButton4()
	{
		
		//pop_04selectcasino.SetActive(false);
	}
	void PopUpPlayNow(){
		Application.LoadLevel ("TexasHoldem");
	}
	
	void PopUpSitNGo(){
		Application.LoadLevel ("TexasHoldem");
	}
	void PopUpSelectCasino(){
		
		Application.LoadLevel ("TexasHoldem");
	}
	// Update is called once per frame
	void Update () {
		
	}
	/*
	public GameObject pop_01buyin; 
	public GameObject pop_02sitngo; 
	public GameObject pop_03selectpicture; 
	public GameObject pop_04selectcasino; 

	// Use this for initialization
	void Start () {
		pop_01buyin.SetActive(false); 
		pop_02sitngo.SetActive(false);
		pop_03selectpicture.SetActive(false);
		pop_04selectcasino.SetActive(false);
	}

	void PopUpButton()
	{
		pop_01buyin.SetActive(true);
	}
	void PopUpButton2()
	{
		pop_02sitngo.SetActive(true);
	}
	void PopUpButton3()
	{
		pop_03selectpicture.SetActive (true);
	}

	void PopUpButton4()
	{
		pop_04selectcasino.SetActive(true);
	}

	void PopUpExitButton()
	{
		pop_01buyin.SetActive(false);
	}
	void PopUpExitButton2()
	{
		pop_02sitngo.SetActive(false);
	}

	void PopUpExitButton3()
	{
		pop_03selectpicture.SetActive(false);
	}
	void PopUpExitButton4()
	{

		pop_04selectcasino.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	*/
}
