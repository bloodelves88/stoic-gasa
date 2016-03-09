using UnityEngine;
using System.Collections;

public class MenuTouches : MonoBehaviour {
	
	public Texture2D button1;
	public Texture2D button2;
	public GUIText loading;
	public AudioClip menuButton;
	private float effectsVolume = 5.0F;
	
	void Start(){
		loading.enabled = false;
		
		if (PlayerPrefs.HasKey ("effectsVolume")) {
			effectsVolume = PlayerPrefs.GetInt ("effectsVolume");
		}
		AudioListener.volume = effectsVolume / 10;
	}
	
	void OnMouseUp(){
		if (this.name == "text_START"){
			Destroy(GameObject.Find ("Music")); // Stop menu music
			StartCoroutine(LoadMainHall());
			StartCoroutine(Loading());
		}
		else if (this.name == "text_Settings"){
			StartCoroutine(LoadSettings ());
		}
		else if (this.name == "text_Back"){
			StartCoroutine(LoadMainMenu ());
		}
		else if (this.name == "text_ClearHighscore"){
			PlayerPrefs.DeleteKey ("highScore");
			GetComponent<GUITexture>().texture = button1;
			GetComponent<AudioSource>().PlayOneShot(menuButton);
		}
		else if (this.name == "text_Backtomenu"){
			StartCoroutine(LoadMainMenu ());
		}
		else if (this.name == "text_Help"){
			StartCoroutine(LoadHelp1 ());
		}
		else if (this.name == "Left_Button"){ // back (help screen)
			if(Application.loadedLevelName == "HelpScreen2"){
				StartCoroutine(LoadHelp1 ());
			}
			else if(Application.loadedLevelName == "HelpScreen3"){
				StartCoroutine(LoadHelp2 ());
			}
		}
		else if (this.name == "Right_Button"){ // forward (help screen)
			if(Application.loadedLevelName == "HelpScreen1"){
				StartCoroutine(LoadHelp2 ());
			}
			else if(Application.loadedLevelName == "HelpScreen2"){
				StartCoroutine(LoadHelp3 ());
			}
		}
	}
	
	void OnMouseDown(){
		if (GetComponent<GUITexture>().name == "text_START")
			GetComponent<GUITexture>().texture = button2;
		else if (GetComponent<GUITexture>().name == "text_Settings")
			GetComponent<GUITexture>().texture = button2;
		else if (GetComponent<GUITexture>().name == "text_Back")
			GetComponent<GUITexture>().texture = button2;
		else if (GetComponent<GUITexture>().name == "text_ClearHighscore"){
			GetComponent<GUITexture>().texture = button2;
		}
		else if (GetComponent<GUITexture>().name == "text_Backtomenu"){
			GetComponent<GUITexture>().texture = button2;
		}
		else if (GetComponent<GUITexture>().name == "text_Help"){
			GetComponent<GUITexture>().texture = button2;
		}
		else if (GetComponent<GUITexture>().name == "Left_Button"){
			GetComponent<GUITexture>().texture = button2;
		}
		else if (GetComponent<GUITexture>().name == "Right_Button"){
			GetComponent<GUITexture>().texture = button2;
		}
	}
	
	IEnumerator Loading(){
		loading.enabled = true;
		yield break;
	}
	IEnumerator LoadSettings(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("settings");
		yield break;
	}
	
	IEnumerator LoadMainMenu(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("mainMenu");
		yield break;
	}
	
	IEnumerator LoadMainHall(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("MainHall");
		yield break;
	}
	
	IEnumerator LoadHelp1(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("HelpScreen1");
		yield break;
	}
	
	IEnumerator LoadHelp2(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("HelpScreen2");
		yield break;
	}
	IEnumerator LoadHelp3(){
		GetComponent<AudioSource>().PlayOneShot(menuButton);
		GetComponent<GUITexture>().texture = button1;
		yield return new WaitForSeconds(0.2F);
		Application.LoadLevel ("HelpScreen3");
		yield break;
	}
}