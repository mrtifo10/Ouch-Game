using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

	public GameObject monsterPrefab;
	public float SpawnTimer = 5;
	public float difficulty = 1;
	public float TimerCopy;
    private float MultiTimer = 4.0f;
    private float Timer = 4.0f;
    //private float wave = 1;
    //private float yieldTime = 1;
    // Use this for initialization
    IEnumerator Wait(int t){
		yield return new WaitForSeconds (t);
		Instantiate (monsterPrefab, transform.position, transform.rotation);
	}
	void Start () {
		TimerCopy = SpawnTimer;

	}
	
	// Update is called once per frame
	void Update () {
        MultiTimer -= Time.deltaTime;
        if(gameObject.tag == "SpawnerM" || gameObject.tag == "SpawnerP")
        {
            if (MultiTimer <= 0)
            {
                Instantiate(monsterPrefab, transform.position, transform.rotation);
                MultiTimer = Timer;
            }
        }
		if (GameManager.gm.score >= 5 && GameManager.gm.score < 10) {
			difficulty = 2; //2
		}
		if (GameManager.gm.score >= 10 && GameManager.gm.score < 15) {
			difficulty = 3;// 3
		}
		if (GameManager.gm.score >= 15 && GameManager.gm.score < 25) {
			difficulty = 4;// 4
		}
		if (GameManager.gm.score >= 25 && GameManager.gm.score < 30) {
			difficulty = 5;// 5
		}
		if (GameManager.gm.score >= 30) {
			difficulty = 6;// 6
		}
		SpawnTimer -= Time.deltaTime;
		/*if (difficulty >= 5) {
			PlayerShoot.ps.cooldownTimer--;
		}
		if (difficulty >= 6) {
			MonsterMovement.mm.moveSpeed++;
		}*/
		if (difficulty >= 2) {
			if (TimerCopy > 4.8f) {
				TimerCopy = TimerCopy - 0.2f;
			}
		}
		if (SpawnTimer <= 0) {
			//Instantiate (monsterPrefab, transform.position, transform.rotation);
			if (transform.tag == "Spawner1" && difficulty >= 1) {
				Instantiate (monsterPrefab, transform.position, transform.rotation);
				//Debug.Log ("asdasdasdasd");
				if (difficulty <= 2) {
					//StartCoroutine (Wait (6));
				}
			}

			if(transform.tag == "Spawner2" && difficulty >= 1){
				Instantiate (monsterPrefab, transform.position, transform.rotation);
				if (difficulty <= 2) {
					//StartCoroutine (Wait (5));
				}
			}

			if (transform.tag == "Spawner3" && difficulty >= 3) {
				Instantiate (monsterPrefab, transform.position, transform.rotation);
			}
				
			if(transform.tag == "Spawner4" && difficulty >= 4){
				Instantiate (monsterPrefab, transform.position, transform.rotation);
			}
			SpawnTimer = TimerCopy;
			}
			
		}
	}

