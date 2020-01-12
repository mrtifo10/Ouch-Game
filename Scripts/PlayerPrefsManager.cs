using UnityEngine;
using System.Collections;

public static class PlayerPrefsManager  {



	public static int getHighScore(){
		if (PlayerPrefs.HasKey ("HighScore")) {
			return PlayerPrefs.GetInt ("HighScore");
		}
		return 0;
	}

	public static void setHighScore(int HighScore){
		PlayerPrefs.SetInt ("HighScore", HighScore);
	}

	public static int getSound(){
		if (PlayerPrefs.HasKey ("SoundOn")) {
			return PlayerPrefs.GetInt ("SoundOn");
		} else {
			setSound (1);
			return 1;
		}
	}

	public static void setSound(int soundOn){
		PlayerPrefs.SetInt ("SoundOn", soundOn);
	}

	public static int getMusic(){
		if (PlayerPrefs.HasKey ("MusicOn")) {
			return PlayerPrefs.GetInt ("MusicOn");
		} else {
			setSound (1);
			return 1;
		}
	}

	public static void setMusic(int soundOn){
		PlayerPrefs.SetInt ("MusicOn", soundOn);
	}

}