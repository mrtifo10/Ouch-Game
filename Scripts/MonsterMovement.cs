using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonsterMovement : MonoBehaviour {
	Vector3 position;
	public static MonsterMovement mm;
	public float moveSpeed = 5;
	private SoundManager sm;
    private bool isMulti = false;
	// Use this for initialization
	void Start () {
		position = transform.position;
		sm = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		mm = gameObject.GetComponent<MonsterMovement> ();
        if(SceneManager.GetActiveScene().name == "Multiplayer")
        {
            isMulti = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!isMulti)
        {
            position.x -= moveSpeed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, -42, 42);
            position.x = Mathf.Clamp(position.x, -50, 50);
            transform.position = position;
        }
        if (isMulti)
        {
            if(gameObject.tag == "MonsterBlue")
            {
                position.x += moveSpeed * Time.deltaTime;
                position.y = Mathf.Clamp(position.y, -42, 42);
                position.x = Mathf.Clamp(position.x, -50, 50);
                transform.position = position;
            }
            if(gameObject.tag == "MonsterRed")
            {
                position.x -= moveSpeed * Time.deltaTime;
                position.y = Mathf.Clamp(position.y, -42, 42);
                position.x = Mathf.Clamp(position.x, -50, 50);
                transform.position = position;
            }
        }
		

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.tag == "Boundry") {
			sm.MonsterWinAudio ();
			Destroy (gameObject);
			GameManager.gm.score--;
			GameManager.gm.updateScore();
		}
        if(gameObject.tag == "MonsterBlue" && col.transform.tag == "boundryBlue")
        {
            sm.MonsterWinAudio();
            Destroy(gameObject);
            GameManager.gm.score1++;
            GameManager.gm.score2--;
            GameManager.gm.updateScore();
        }
        if (gameObject.tag == "MonsterRed" && col.transform.tag == "boundryRed")
        {
            sm.MonsterWinAudio();
            Destroy(gameObject);
            GameManager.gm.score2++;
            GameManager.gm.score1--;
            GameManager.gm.updateScore();
        }
    }
}
