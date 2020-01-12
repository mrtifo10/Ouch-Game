using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Vector3 position;
	Camera cam;

	void Start(){
		cam = gameObject.GetComponent<Camera> ();
		if (cam.aspect > 1.7) {
			cam.orthographicSize = 30;
		} else if (cam.aspect > 1.5) {
			cam.orthographicSize = 33;
		} else if (cam.aspect >= 1.4) {
			cam.orthographicSize = 36;
		} else if (cam.aspect > 1.26) {
			cam.orthographicSize = 38;
		} else if (cam.aspect > 1) {
			cam.orthographicSize = 40;
		}
	}
}
