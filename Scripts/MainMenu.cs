using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Text SoundOn;
	public Text Music;

	public GameObject MainMenuCanvas;
	public GameObject OptionsCanvas;

	void Awake(){
		OptionsCanvas.SetActive(false);
		MainMenuCanvas.SetActive (true);
		updateMuandSo ();
	}

	private void updateMuandSo() {
		if (PlayerPrefsManager.getSound () == 1) {
			SoundOn.text = "Sound : ON ";
		} else {
			SoundOn.text = "Sound : OFF";
		}
		if (PlayerPrefsManager.getMusic () == 1) {
			Music.text = "Music : ON";
		} else {
			Music.text = "Music : OFF";
		}
	}

	public void optionON(){
		OptionsCanvas.SetActive(true);
		MainMenuCanvas.SetActive(false);
	}

	public void ReturnToMenu(){
		OptionsCanvas.SetActive(false);
		MainMenuCanvas.SetActive(true);
	}

	public void PlaySingle(){
		SceneManager.LoadScene (1);
	}

    public void PlayCoop()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayMulti()
    {
        SceneManager.LoadScene(3);
    }

    public void setSound() {
		if (PlayerPrefsManager.getSound () == 1) {
			PlayerPrefsManager.setSound (0);
		} else {
			PlayerPrefsManager.setSound (1);
		}
		updateMuandSo ();
	}

	public void setMusic() {
		if (PlayerPrefsManager.getMusic () == 1) {
			PlayerPrefsManager.setMusic (0);
		} else {
			PlayerPrefsManager.setMusic (1);
		}
		updateMuandSo ();
	}

	public void Exit() {
		Application.Quit ();
	}

	void Update() {
		if (PlayerPrefsManager.getMusic () == 0) {
			gameObject.GetComponent<AudioSource> ().mute = true;
		} else {
			gameObject.GetComponent<AudioSource> ().mute = false;
		}

	}
}
