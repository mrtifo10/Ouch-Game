using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {
	private MonsterMovement mv;
	private PlayerShoot ps;
	private SoundManager sm;
	private Rigidbody2D rb;
	private bool friendFire = false;
	//public AudioClip MonsterDeathSound;
	//public AudioClip MonsterWinSound;


	Animator anim;
	bool MonsterDead(){
		return true;
	}

	private GameObject currentObj;
	public int health = 1;
	// Use this for initialization
	void Start () {
		currentObj = gameObject;
		mv = transform.GetComponent<MonsterMovement> ();
		ps = transform.GetComponent<PlayerShoot> ();
		rb = transform.GetComponent<Rigidbody2D> ();
		anim = transform.GetComponent<Animator> ();
		sm = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
		StartCoroutine(LateStart(1));
		//putGameManagerHERE.GetComponent<GameManager> ().updateScore ();
	}

	IEnumerator LateStart(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		friendFire = GameManager.gm.friendlyFire;
	}

	IEnumerator MonsterDeath(){
		sm.MonsterDeathAudio();
		mv.moveSpeed = 0;
		ps.Fire = false;
		anim.SetTrigger ("MonsterShoot");
		Destroy (transform.GetComponent<BoxCollider2D> ());
		//transform.GetComponent<Rigidbody2D> ().freezeRotation = false;
		//transform.GetComponent<Rigidbody2D> ().gravityScale = 10;
		rb.gravityScale = 1;
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.gm.score <= -10 && (currentObj.tag == "Player" || currentObj.tag == "Player2")) {
			health--;
			GameManager.gm.score = 0;
			GameManager.gm.updateScore ();
		}
		if (health <= 0 && (currentObj.tag == "Player" || currentObj.tag == "Player2")) {
			Destroy (gameObject);
		}

		if (GameManager.gm.highestCurrentScore % 30 == 0 && GameManager.gm.highestCurrentScore != 0 
			&& GameManager.gm.healthUp == true && (currentObj.tag == "Player" || currentObj.tag == "Player2")) {
			GameManager.gm.healthUp = false;
			if (health < 5) {
				health++;
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D col) {
		if((currentObj.tag == "Player" || currentObj.tag == "Player2") && col.gameObject.tag == "Monster"){
			health--;
			sm.PlayerD ();
		}
        if(currentObj.tag == "Player" && col.gameObject.tag == "Player2M")
        {
            health--;
        }
        if (currentObj.tag == "Player2M" && col.gameObject.tag == "Player")
        {
            health--;
        }
        if (currentObj.tag == "Player" && col.gameObject.tag == "MonsterRed")
        {
            health--;
            sm.PlayerD();
        }
        if (currentObj.tag == "Player2M" && col.gameObject.tag == "MonsterBlue")
        {
            health--;
            sm.PlayerD();
        }
        if (currentObj.tag == "Monster" && (col.gameObject.tag == "Player" || col.gameObject    .tag == "Player2")) {
			health--;
			if (health <= 0) {
				StartCoroutine (MonsterDeath ());
				GameManager.gm.score++;
				GameManager.gm.updateScore ();
			}
		}
        if(currentObj.tag == "MonsterRed" && col.gameObject.tag == "Player")
        {
            health--;
            if (health <= 0)
            {
                StartCoroutine(MonsterDeath());
                GameManager.gm.score1++;
                GameManager.gm.updateScore();
            }
        }
        if (currentObj.tag == "MonsterBlue" && col.gameObject.tag == "Player2M")
        {
            health--;
            if (health <= 0)
            {
                StartCoroutine(MonsterDeath());
                GameManager.gm.score2++;
                GameManager.gm.updateScore();
            }
        }
        if (currentObj.tag == "Monster" && col.gameObject.tag == "bullet"){
			health--;
			if (health <= 0) {
				StartCoroutine (MonsterDeath ());
				GameManager.gm.score++;
				GameManager.gm.updateScore ();
			}
		}
        if(currentObj.tag == "MonsterRed" && (col.gameObject.tag == "blueBullet" || col.gameObject.tag == "bullet"))
        {
            health--;
            if (health <= 0)
            {
                StartCoroutine(MonsterDeath());
                GameManager.gm.score1++;
                GameManager.gm.updateScore();
            }
        }
        if (currentObj.tag == "MonsterBlue" && (col.gameObject.tag == "redBullet" || col.gameObject.tag == "bulletM"))
        {
            health--;
            if (health <= 0)
            {
                StartCoroutine(MonsterDeath());
                GameManager.gm.score2++;
                GameManager.gm.updateScore();
            }
        }
       
        if ((currentObj.tag == "Player" || currentObj.tag == "Player2") && col.gameObject.tag == "bullet2") {
			health--;
			sm.PlayerD ();
			if (health <= 0) {
				sm.MonsterWinAudio ();
				Destroy (gameObject);
			}
		}
        if(currentObj.tag == "Player" && (col.gameObject.tag == "redBullet" || col.gameObject.tag == "bulletM"))
        {
            health--;
            sm.PlayerD();
            if (health <= 0)
            {
                sm.MonsterWinAudio();
                Destroy(gameObject);
            }
        }
        if (currentObj.tag == "Player2M" && (col.gameObject.tag == "blueBullet" || col.gameObject.tag == "bullet"))
        {
            health--;
            sm.PlayerD();
            if (health <= 0)
            {
                sm.MonsterWinAudio();
                Destroy(gameObject);
            }
        }
        if (friendFire) {
			if (currentObj.tag == "Player" && col.gameObject.tag == "bullet"
				&& currentObj != col.gameObject.GetComponent<Bullet>().getShooter()) {
				health--;
				sm.PlayerD ();
				if (health <= 0) {
					sm.MonsterWinAudio ();
					Destroy (gameObject);
				}
			}
		}
	}
}
