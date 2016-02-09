using UnityEngine;
using System.Collections;

public class CannonMovement : MonoBehaviour {

	[SerializeField] private Transform vrCamera;
	[SerializeField] private Transform cannon;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float rotationSpeed;
	[SerializeField] private Terrain floor;

	public float distanceFromCamera = 40f;
	private Quaternion initialVrCameraRotation;
	//private float distanceFromGround;

	// Use this for initialization
	void Start (){
		string[] joysticNames = Input.GetJoystickNames();
		print (joysticNames);
		//distanceFromGround = cannon.position.y - floor.transform.position.y;
		//initialVrCameraRotation = vrCamera.transform.rotation;
		//cannon.position = vrCamera.position + distanceFromCamera*vrCamera.forward;
		//cannon.rotation = vrCamera.rotation * Quaternion.Euler(90, 270, 0);

		//vrCamera.position = cannon.position - distanceFromCamera * cannon.forward.normalized;
		//vrCamera.rotation = cannon.rotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var verticalDir = Input.GetAxis ("Vertical");
		var horizontalDir = Input.GetAxis ("Horizontal");
		Debug.DrawRay (cannon.position, cannon.right, Color.red, 100f);
		Debug.DrawRay (cannon.position, cannon.forward, Color.green, 100f);


		if (Mathf.Abs (verticalDir) > 0.01) {
			//cannon.forward = Vector3.Lerp (vrCamera.forward.normalized, cannon.forward.normalized, Time.deltaTime);
			//vrCamera.Translate (vrCamera.forward.normalized * (movementSpeed * verticalDir));
			cannon.Translate (/*new Vector3 (0, cannon.forward.z, -1 * cannon.forward.x )*/cannon.right.normalized * verticalDir * movementSpeed);
			//cannon.rotation = vrCamera.rotation * Quaternion.Euler(90, 270, 0);
		}

		if (Mathf.Abs(horizontalDir) > 0.01 ) {
			//making the camara rotate with this inputs is a dumb idea if we're gonna do a VR demo
			//vrCamera.RotateAround (vrCamera.position, Vector3.up, rotationSpeed * horizontalDir);

			//the following commentede code was used if the camera wasn't a child of the cannon (it's still wrong though)
			//cannon.right = Vector3.Lerp (vrCamera.right.normalized, cannon.right.normalized, Time.deltaTime);
			//vrCamera.Translate (vrCamera.right.normalized * (movementSpeed * horizontalDir));
			cannon.Translate (cannon.forward.normalized * horizontalDir * movementSpeed * -1);
			//cannon.rotation = vrCamera.rotation * Quaternion.Euler(90, 270, 0);
		}

		//cannon.position = vrCamera.forward + distanceFromCamera * vrCamera.forward.normalized;

		//float h = Input.GetAxis("Mouse X") * rotationSpeed;
		//float v = Input.GetAxis ("Mouse Y") * rotationSpeed;
		//cannon.Rotate (0, h, 0);
		//Debug.DrawRay (cannon.position, cannon.forward);
	}
}