using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
	public static GameManager gm;
	public int score = 0;
	public UnityEngine.UI.Text textScore;
	public GameObject[] image;
    public GameObject[] image2;
	public GameObject GameOverCanvas;
	public GameObject MainCanvas;
	public Text ScoreText;
	public Text HighScoreText;
	public GameObject cameraMain;
	public GameObject pauseCanvas;
	private DamageHandler dm;
    private DamageHandler dm2;
	private bool playing = true;
	private int currentHighScore;
	private SoundManager sm;
	[HideInInspector]
	public int highestCurrentScore = 0;
	[HideInInspector]
	public bool healthUp = true;
	private bool paused = false;
	public bool friendlyFire = false;
    private bool isCoop = false;
    private bool isMulti = false;
    public int score1 = 0;
    public int score2 = 0;
    public Text Score1Text;
    public Text Score2Text;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text GameOverText;

    void Start(){
        if (SceneManager.GetActiveScene().name == "Coop")
        {
            isCoop = true;
        }
        if(SceneManager.GetActiveScene().name == "Multiplayer")
        {
            isMulti = true;
           
        }
            if (PlayerPrefsManager.getMusic () == 0) {
			cameraMain.GetComponent<AudioSource> ().mute = true;
		} else {
			cameraMain.GetComponent<AudioSource> ().mute = false;
		}
		gm = gameObject.GetComponent<GameManager>();
        dm = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageHandler>();
        if(isCoop)
        {
            dm2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<DamageHandler>();
        }
        sm = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
//		defaultScore = score;
		MainCanvas.SetActive(true);
		GameOverCanvas.SetActive (false);
		pauseCanvas.SetActive (false);
		playing = true;
		currentHighScore = PlayerPrefsManager.getHighScore ();
        if (isMulti)
        {
            dm2 = GameObject.FindGameObjectWithTag("Player2M").GetComponent<DamageHandler>();
            GameObject.FindGameObjectWithTag("SC").SetActive(false);
        }
	}

	public void updateScore(){
        if (isMulti)
        {
            Score1Text.text = "Player1 : " + score1;
            Score2Text.text = "Player2 : " + score2;
        }
		textScore.text = "Score : " + score;
        
		//WaveTimer -= Time.deltaTime;

	}

	void Update(){
		if (playing) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				if (paused) {
					paused = false;
					pauseCanvas.SetActive (false);
					Time.timeScale = 1;
				} else {
					paused = true;
					pauseCanvas.SetActive (true);
					Time.timeScale = 0;
				}
			}
			if (score != highestCurrentScore) {
				healthUp = true;
			}
			if (score > currentHighScore) {
				currentHighScore = score;
			}
			if (score > highestCurrentScore) {
				highestCurrentScore = score;
			}
			if (dm.health == 5) {
				foreach (GameObject im in image) {
					im.SetActive (true);
				}
			} 
			if (dm.health == 4) {
				image [0].SetActive (true);
				image [1].SetActive (true);
				image [2].SetActive (true);
				image [3].SetActive (true);
				image [4].SetActive (false);
			}
			if (dm.health == 3) {
				image [0].SetActive (true);
				image [1].SetActive (true);
				image [2].SetActive (true);
				image [3].SetActive (false);
				image [4].SetActive (false);
			} 
			if (dm.health == 2) {
				image [0].SetActive (true);
				image [1].SetActive (true);
				image [2].SetActive (false);
				image [3].SetActive (false);
				image [4].SetActive (false);
			}
			if (dm.health == 1) {
				image [0].SetActive (true);
				image [1].SetActive (false);
				image [2].SetActive (false);
				image [3].SetActive (false);
				image [4].SetActive (false);
			}
            if(dm.health == 0 && (!isCoop && !isMulti))
            {
                foreach (GameObject im in image)
                {
                    im.SetActive(false);
                }
                cameraMain.GetComponent<AudioSource>().mute = true;
                PlayerPrefsManager.setHighScore(currentHighScore);
                sm.GameOver();
                playing = false;
                GameOverCanvas.SetActive(true);
                MainCanvas.SetActive(false);
                ScoreText.text = "Score : " + score;
                HighScoreText.text = "HighScore : " + PlayerPrefsManager.getHighScore();
            }


            if (isCoop || isMulti)
            {
                if (dm2.health == 5)
                {
                    foreach (GameObject im2 in image2)
                    {
                        im2.SetActive(true);
                    }
                }
                if (dm2.health == 4)
                {
                    image2[0].SetActive(true);
                    image2[1].SetActive(true);
                    image2[2].SetActive(true);
                    image2[3].SetActive(true);
                    image2[4].SetActive(false);
                }
                if (dm2.health == 3)
                {
                    image2[0].SetActive(true);
                    image2[1].SetActive(true);
                    image2[2].SetActive(true);
                    image2[3].SetActive(false);
                    image2[4].SetActive(false);
                }
                if (dm2.health == 2)
                {
                    image2[0].SetActive(true);
                    image2[1].SetActive(true);
                    image2[2].SetActive(false);
                    image2[3].SetActive(false);
                    image2[4].SetActive(false);
                }
                if (dm2.health == 1)
                {
                    image2[0].SetActive(true);
                    image2[1].SetActive(false);
                    image2[2].SetActive(false);
                    image2[3].SetActive(false);
                    image2[4].SetActive(false);
                }

                if (dm.health == 0)
                {
                    foreach (GameObject im in image)
                    {
                        im.SetActive(false);
                    }

                }

                if (dm2.health == 0)
                {
                    foreach (GameObject im in image)
                    {
                        im.SetActive(false);
                    }

                }

                if (dm.health == 0 && isMulti)
                {
                    foreach (GameObject im in image)
                    {
                        im.SetActive(false);
                    }
                    cameraMain.GetComponent<AudioSource>().mute = true;
                    sm.GameOver();
                    playing = false;
                    GameOverCanvas.SetActive(true);
                    MainCanvas.SetActive(false);
                    Player1ScoreText.text = "Player1 : " + score1;
                    Player2ScoreText.text = "Player2 : " + score2;
                    GameOverText.text = "Player2 Wins!";
                }

                if(dm2.health == 0 && isMulti)
                {
                    foreach (GameObject im2 in image2)
                    {
                        im2.SetActive(false);
                    }
                    cameraMain.GetComponent<AudioSource>().mute = true;
                    sm.GameOver();
                    playing = false;
                    GameOverCanvas.SetActive(true);
                    MainCanvas.SetActive(false);
                    Player1ScoreText.text = "Player1 : " + score1;
                    Player2ScoreText.text = "Player2 : " + score2;
                    GameOverText.text = "Player1 Wins!";
                }

                }


                if (isCoop && dm.health == 0 && dm2.health == 0)
                {
                    cameraMain.GetComponent<AudioSource>().mute = true;
                    PlayerPrefsManager.setHighScore(currentHighScore);
                    sm.GameOver();
                    playing = false;
                    GameOverCanvas.SetActive(true);
                    MainCanvas.SetActive(false);
                    ScoreText.text = "Score : " + score;
                    HighScoreText.text = "HighScore : " + PlayerPrefsManager.getHighScore();
                }
            }
            

		}
    public void unlockPause()
    {
        paused = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void loadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}


	// Use this for initialization
	

	