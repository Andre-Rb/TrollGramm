using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class StartOptions : MonoBehaviour {



	public int sceneToStart = 1;									
										


	[HideInInspector] public bool inMainMenu = true;					//If true, pause button disabled in main menu (Cancel in input manager, default escape key)
	[HideInInspector] public Animator animColorFade; 					//Reference to animator which will fade to and from black when starting game.
	[HideInInspector] public Animator animMenuAlpha;					//Reference to animator that will fade out alpha of MenuPanel canvas group
	 public AnimationClip fadeColorAnimationClip;		//Animation clip fading to color (black default) when changing scenes
	[HideInInspector] public AnimationClip fadeAlphaAnimationClip;		//Animation clip fading out UI elements alpha



	private PlayMusic playMusic;										//Reference to PlayMusic script
	//private float fastFadeIn = .1f;									//Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
	private ShowPanels showPanels;										//Reference to ShowPanels script on UI GameObject, to show and hide panels




	//**********
	//Modifié
	PreviousLevel PreviousLevel;
	public int levelMusic;

	//**********

	void Awake()
	{
		PreviousLevel = GetComponent <PreviousLevel>();


		//Get a reference to ShowPanels attached to UI object
		showPanels = GetComponent<ShowPanels> ();

		//Get a reference to PlayMusic attached to UI object
		playMusic = GetComponent<PlayMusic> ();

		// inutil ShowPanel = GetComponent <ShowPanels> ();

	}


	public void StartButtonClicked()
	{
			inMainMenu = false;
			playMusic.FadeDown(3f);

			//Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
			Invoke ("LoadDelayed", fadeColorAnimationClip.length * .5f);

			//Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
			animColorFade.SetTrigger ("fade");


	}


	//Once the level has loaded, check if we want to call PlayLevelMusic
	void OnLevelWasLoaded(){
		//Debug.Log ("test1, StartOption");
		playMusic.FadeDown(0.01f);
		if ( PreviousLevel.isOld != true)//*****************************************************************************************<------Music lEVEL
		{
			playMusic.PlayLevelMusic ();
			playMusic.FadeUp(0.01f);
			//Debug.Log (SceneManager.GetActiveScene().buildIndex);
		}	
	}


	public void LoadDelayed()
	{

		//Hide the main menu UI element
		showPanels.HideMenu ();

		//Load the selected scene, by scene index number in build settings
		SceneManager.LoadScene (sceneToStart);
	}

	public void HideDelayed()
	{
		//Hide the main menu UI element after fading out menu for start game in scene
		showPanels.HideMenu();
	}
		

}
