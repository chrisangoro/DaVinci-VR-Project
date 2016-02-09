using UnityEngine;
using System.Collections;

public class museumLook : MonoBehaviour {

	[SerializeField] private Transform invento1;
	//[SerializeField] private Transform invento2;
	//[SerializeField] private Transform invento3;
	//[SerializeField] private Transform invento4;
	[SerializeField] private Ray cameraCenter;
	[SerializeField] private Transform mainCamera;
	[SerializeField] private TextMesh textI1;
	//[SerializeField] private TextMesh textI2;
	//[SerializeField] private TextMesh textI3;
	//[SerializeField] private TextMesh textI4;
	[SerializeField] private float rotVelX;
	[SerializeField] private float rotVelY;


	private Vector3 startPosInv1;
	//private Vector3 startPosInv2;
	//private Vector3 startPosInv3;
	//private Vector3 startPosInv4;
	private Quaternion startRotInv1;
	//private Quaternion startRotInv2;
	//private Quaternion startRotInv3;
	//private Quaternion startRotInv4;
	private bool lookedAtInv1;
	//private bool lookedAtInv2;
	//private bool lookedAtInv3;
	//private bool lookedAtInv4;

	// Use this for initialization
	void Start () {
		startPosInv1 = invento1.position;
		//startPosInv2 = invento2.position;
		//startPosInv3 = invento3.position;
		//startPosInv4 = invento4.position;

		startRotInv1 = invento1.rotation;
		//startRotInv2 = invento2.rotation;
		//startRotInv3 = invento3.rotation;
		//startRotInv4 = invento4.rotation;

		lookedAtInv1 = false;
		//lookedAtInv2 = false;
		//lookedAtInv3 = false;
		//lookedAtInv4 = false;
	}

	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if(Physics.Raycast(mainCamera.position, mainCamera.forward.normalized, out hit)){
			Transform objectHit = hit.transform;
			//print ("mira a " + objectHit);													//test to see what the camera is looking
			if (objectHit.name.Equals(invento1.name)) {
				print ("aleluya " + objectHit);
				float xDeg = Input.GetAxis ("Horizontal");
				float yDeg = Input.GetAxis ("Vertical");
				if (Mathf.Abs (yDeg) > 0.01) {
					//invento1.Rotate (yDeg*rotVelY, 0 ,0);
					invento1.RotateAround (Vector3.up, Vector3.right, rotVelX);
					print ("position: " + invento1.position);
					print ("rotation: " + invento1.rotation);
				}
				invento1.position = startPosInv1;
				if (Mathf.Abs(xDeg) > 0.01 ) {
					invento1.Rotate (0, xDeg*rotVelX*-1, 0);
					print ("position: " + invento1.position);
					print ("rotation: " + invento1.rotation);
				}
			}
		}
		invento1.position.Set(startPosInv1.x, startPosInv1.y, startPosInv1.z);
		//print ("current pos: " + invento1.position + " || initial pos: " + startPosInv1 );
		//invento1.position = startPosInv2;
		//invento1.position = startPosInv3;
		//invento1.position = startPosInv4;
	}
}