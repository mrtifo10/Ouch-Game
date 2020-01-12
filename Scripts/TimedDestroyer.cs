using UnityEngine;
using System.Collections;

public class TimedDestroyer : MonoBehaviour {
	public float waitTime = 1.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine (destroyMe ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator destroyMe() {
		yield return new WaitForSeconds(waitTime);
		Destroy(gameObject);
	}
}
