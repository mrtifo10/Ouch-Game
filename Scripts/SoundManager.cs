using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioClip PlayerLaserSound;
	public AudioClip MonsterLaserSound;
	public AudioClip MonsterDeathSound;
	public AudioClip MonsterWinSound;
	public AudioClip[] PlayerDamaged;
	public AudioClip GameOverSound;
	[Range(0.0f, 1.0f)]
	public float voiceScale = 0.5f;
	[Range(0.0f, 1.0f)]
	public float voiceScale2 = 0.3f;
	[Range(0.0f, 1.0f)]
	public float voiceScale3 = 1f;
	//public AudioClip GameMusic;
	private AudioSource audioo;
	private AudioSource character;


	 //Use this for initialization
	void Start () {
		audioo = transform.GetComponents<AudioSource>()[0];
		character = gameObject.GetComponents<AudioSource> ()[1];
		//audioo.play;
	}

	public void MonsterWinAudio(){
		if(PlayerPrefsManager.getSound() == 1)
			audioo.PlayOneShot (MonsterWinSound,voiceScale);
	}
	public void MonsterDeathAudio(){
		if(PlayerPrefsManager.getSound() == 1)
			audioo.PlayOneShot (MonsterDeathSound,voiceScale);
	}
	public void PlayerShotAudio(){
		if(PlayerPrefsManager.getSound() == 1)
			audioo.PlayOneShot (PlayerLaserSound,voiceScale2);
	}
	public void MonsterShotAudio(){
		if(PlayerPrefsManager.getSound() == 1)
			audioo.PlayOneShot (MonsterLaserSound,voiceScale2);
	}
	public void PlayerD(){
		if (!character.isPlaying) {
			character.PlayOneShot (PlayerDamaged [Random.Range (0, 3)], voiceScale3);
		}
	}

	public void GameOver(){
		audioo.PlayOneShot (GameOverSound,voiceScale3);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
