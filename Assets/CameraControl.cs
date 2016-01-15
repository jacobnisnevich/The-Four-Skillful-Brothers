using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Vertical"), Space.World);
        gameObject.transform.Translate(Vector3.right * Input.GetAxis("Horizontal"), Space.World);
        gameObject.transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel"));
	}
}
