using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private Transform currentBullet;
	public Transform bulletEffect;
	Vector3 temp = new Vector3 (0.3f, 0, 0);
	public float Timer = 4;
	public float moveSpeed = 15;
	public int health = 1;
	Vector3 position;
	private bool directionRight = false;
	private GameObject shooter;
	// Use this for initialization
	void Start () {
		position = transform.position;
		currentBullet = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Timer -= Time.deltaTime;
		if (Timer <= 0) {
			if (currentBullet.tag == "bullet" || currentBullet.tag == "bulletM") {
				Instantiate (bulletEffect, transform.position + temp, transform.rotation);
                Object.Destroy(gameObject);
			}
			if (currentBullet.tag == "bullet2") {
				Instantiate (bulletEffect, transform.position - temp, transform.rotation);
                Object.Destroy(gameObject);
            }
		}
		if (currentBullet.tag == "bullet" || currentBullet.tag == "bulletM") {
			if (directionRight) {
				position.x += moveSpeed * Time.deltaTime;
			} else {
				position.x -= moveSpeed * Time.deltaTime;
			}
		}
		if (currentBullet.tag == "bullet2") {
			position.x -= moveSpeed * Time.deltaTime;
		}
        if(currentBullet.tag == "blueBullet")
        {
            position.x += moveSpeed * Time.deltaTime;
        }
        if(currentBullet.tag == "redBullet")
        {
            position.x -= moveSpeed * Time.deltaTime;
        }
		//position.y += moveSpeed * Time.deltaTime;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject != shooter && (currentBullet.tag == "bullet" || currentBullet.tag == "bulletM")) {
			Instantiate (bulletEffect, transform.position + temp, transform.rotation);
            Destroy(gameObject);
		}
		if ((currentBullet.tag == "bullet" || currentBullet.tag == "bulletM") && (col.gameObject.tag != "Player" || col.gameObject.tag != "Player2")) {
			Instantiate (bulletEffect, transform.position + temp, transform.rotation);
			Destroy (gameObject);
		}
		if (currentBullet.tag == "bullet2" && col.gameObject.tag != "Monster") {
			Instantiate (bulletEffect, transform.position + temp, transform.rotation);
			Destroy(gameObject);
		}
        if (currentBullet.tag == "redBullet" && col.gameObject.tag != "MonsterRed")
        {
            Instantiate(bulletEffect, transform.position + temp, transform.rotation);
            Destroy(gameObject);
        }
        if (currentBullet.tag == "blueBullet" && col.gameObject.tag != "MonsterBlue")
        {
            Instantiate(bulletEffect, transform.position + temp, transform.rotation);
            Destroy(gameObject);
        }
    }

	public void setBulletRight() {
		directionRight = true;
	}

	public GameObject getShooter() {
		return shooter;
	}

	public void setShooter(GameObject shooter) {
		this.shooter = shooter;
	}
}
