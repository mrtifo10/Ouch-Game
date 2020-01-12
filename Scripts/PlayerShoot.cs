using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
	//public AudioClip PlayerLaserSound;
	//public AudioClip MonsterLaserSound;
	//Animator anim;
    
	public bool Fire = true;
	Transform currentObj;
	Vector3 temp = new Vector3(2.5f, 0, 0);
	public GameObject bulletPrefab;
	public float cooldownTimer = 3f;
	private float cT;
	private SoundManager sm;
	public string fireAxis = "Fire1";
	// Use this for initialization
	void Start () {
		//temp = transform.position;
		cT = cooldownTimer;
		currentObj = transform;
		sm = GameObject.FindGameObjectWithTag ("SoundManager").GetComponent<SoundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if (currentObj.tag == "Player" || currentObj.tag == "Player2" || currentObj.tag == "Player2M") {
			if (Input.GetButton (fireAxis) && cooldownTimer <= 0) {
				sm.PlayerShotAudio ();
				cooldownTimer = cT;
				//emp.x += 0.5f;
				if (currentObj.GetComponent<PlayerMovement> ().facingRight) {
					GameObject bull = (GameObject) Instantiate(bulletPrefab, transform.position + temp, transform.rotation);
					bull.GetComponent<Bullet> ().setBulletRight ();
					bull.GetComponent<Bullet> ().setShooter(gameObject);
				} else {
					GameObject bull = (GameObject)Instantiate (bulletPrefab, transform.position - temp, transform.rotation);
					bull.GetComponent<Bullet> ().setShooter(gameObject);
				}

			}
		}
		if (currentObj.tag == "Monster" || currentObj.tag == "MonsterRed" || currentObj.tag == "MonsterBlue") {
			if (cooldownTimer <= 0 && Fire == true) {
				sm.MonsterShotAudio ();
				cooldownTimer = cT;
                if(currentObj.tag == "MonsterBlue")
                {
                    GameObject bull = (GameObject)Instantiate(bulletPrefab, transform.position + temp, transform.rotation);
                    bull.GetComponent<Bullet>().setShooter(gameObject);
                }
                else
                {
                    GameObject bull = (GameObject)Instantiate(bulletPrefab, transform.position - temp, transform.rotation);
                    bull.GetComponent<Bullet>().setShooter(gameObject);
                }
				
				
			}
		}
	}
}
