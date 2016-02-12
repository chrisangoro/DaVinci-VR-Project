using UnityEngine;
using System.Collections;

public class museumLook : MonoBehaviour {

	[SerializeField] private Transform invento1;
	[SerializeField] private Transform invento2;
	[SerializeField] private Transform invento3;
	[SerializeField] private Transform invento4;
	[SerializeField] private Ray cameraCenter;
	[SerializeField] private Transform mainCamera;
	[SerializeField] private TextMesh textI1;
	//[SerializeField] private TextMesh textI2;
	//[SerializeField] private TextMesh textI3;
	//[SerializeField] private TextMesh textI4;
	[SerializeField] private float rotVelX;
	[SerializeField] private float rotVelY;
	[SerializeField] private float movementSpeed;

    CardboardHead cardboardHead;

	private float xDeg;
	private float yDeg;
	private Vector3 startPosInv1;
	private Vector3 startPosInv2;
	private Vector3 startPosInv3;
	private Vector3 startPosInv4;
    private Vector3 startForwardCamera;
    private Vector3 startRightCamera;
	private Quaternion startRotInv1;
	//private Quaternion startRotInv2;
	//private Quaternion startRotInv3;
	//private Quaternion startRotInv4;
	private bool lookedAtInv1;
	private bool lookedAtInv2;
	private bool lookedAtInv3;
	private bool lookedAtInv4;

	// Use this for initialization
	void Start () {
		startPosInv1 = invento1.position;
		startPosInv2 = invento2.position;
		startPosInv3 = invento3.position;
		startPosInv4 = invento4.position;
        startForwardCamera = mainCamera.forward;
        startRightCamera = mainCamera.right;

		startRotInv1 = invento1.rotation;
		//startRotInv2 = invento2.rotation;
		//startRotInv3 = invento3.rotation;
		//startRotInv4 = invento4.rotation;

		lookedAtInv1 = false;
		lookedAtInv2 = false;
		lookedAtInv3 = false;
		lookedAtInv4 = false;

        cardboardHead = Camera.main.GetComponent<StereoController>().Head;
	}

	// Update is called once per frame
	void Update () {

		RaycastHit hit;

		if(!lookedAtInv1 && !lookedAtInv2 && !lookedAtInv3 && !lookedAtInv4){
			var xMov = Input.GetAxis ("Horizontal");
			var yMov = Input.GetAxis ("Vertical");


			if (Mathf.Abs (xMov) > 0.01) {
                Vector3 forward = new Vector3(-cardboardHead.transform.forward.x, 0, cardboardHead.transform.forward.z).normalized;
				mainCamera.Translate (forward * movementSpeed * -xMov);
			}
			if (Mathf.Abs (yMov) > 0.01) {
                Vector3 right = new Vector3(cardboardHead.transform.right.x, 0, cardboardHead.transform.right.z).normalized;
				mainCamera.Translate (right * movementSpeed * yMov);
			}
		}

		//print ("current pos: " + invento1.position + " || initial pos: " + startPosInv1 );
		//invento1.position = startPosInv2;
		//invento1.position = startPosInv3;
		//invento1.position = startPosInv4;

		if(Physics.Raycast(mainCamera.position, mainCamera.forward.normalized, out hit)){
			Transform objectHit = hit.transform;
			//print ("mira a " + objectHit);                                              //test to see what the camera is looking


            if (objectHit.name.Equals ("Davinci")) {
                if (Input.GetKey("q"))
                {
                    lookedAtInv1 = true;
                }
            }

            if (objectHit.name.Equals("Bici")) {
                if (Input.GetKey("q"))
                {
                    lookedAtInv2 = true;
                }
            }

            if (objectHit.name.Equals("Intento")) {
                if (Input.GetKey("q"))
                {
                    lookedAtInv3 = true;
                }
            }

            if (objectHit.name.Equals("DaVinciCannon")) {
                if (Input.GetKey("q"))
                {
                    lookedAtInv4 = true;
                }
            }

/*---------------------------------------------------------INVENTO 1----------------------------------------------------------*/

            if (lookedAtInv1){
				//print ("aleluya " + objectHit);
				xDeg = (Input.GetAxis ("Horizontal"));
				yDeg = (Input.GetAxis ("Vertical"));				

				if (Mathf.Abs (xDeg) > 0.01) {
					invento1.Rotate (0 , -1 * xDeg * rotVelX, 0);
				}
				invento1.position = startPosInv1;
				/*if (Mathf.Abs(yDeg) > 0.01 ) {
					invento1.Rotate (yDeg * rotVelY, 0, 0);
				}*/
				if (Input.GetKey ("q")) {
					lookedAtInv1 = false;
				}
			}

/*---------------------------------------------------------INVENTO 2----------------------------------------------------------*/

            if (lookedAtInv2)
            {
               // print("aleluya " + objectHit);
                xDeg = (Input.GetAxis("Horizontal"));
                yDeg = (Input.GetAxis("Vertical"));

                if (Mathf.Abs(xDeg) > 0.01)
                {
                    invento2.Rotate(0, 0, -1 * xDeg * rotVelX);
                }
                invento2.position = startPosInv2;
                /*if (Mathf.Abs(yDeg) > 0.01 ) {
					invento1.Rotate (yDeg * rotVelY, 0, 0);
				}*/
                if (Input.GetKey("q"))
                {
                    lookedAtInv2 = false;
                }
            }

/*---------------------------------------------------------INVENTO 3----------------------------------------------------------*/

            if (lookedAtInv3)
            {
               // print("aleluya " + objectHit);
                xDeg = (Input.GetAxis("Horizontal"));
                yDeg = (Input.GetAxis("Vertical"));

                if (Mathf.Abs(xDeg) > 0.01)
                {
                    invento3.Rotate(0, 0, -1 * xDeg * rotVelX);
                }
                invento3.position = startPosInv3;
                /*if (Mathf.Abs(yDeg) > 0.01 ) {
					invento1.Rotate (yDeg * rotVelY, 0, 0);
				}*/
                if (Input.GetKey("q"))
                {
                    lookedAtInv3 = false;
                }
            }

/*---------------------------------------------------------INVENTO 4----------------------------------------------------------*/

            if (lookedAtInv4)
            {
               // print("aleluya " + objectHit);
                xDeg = (Input.GetAxis("Horizontal"));
                yDeg = (Input.GetAxis("Vertical"));

                if (Mathf.Abs(xDeg) > 0.01)
                {
                    invento4.Rotate(0, 0, -1 * xDeg * rotVelX);
                }
                invento4.position = startPosInv4;
                /*if (Mathf.Abs(yDeg) > 0.01 ) {
					invento1.Rotate (yDeg * rotVelY, 0, 0);
				}*/
                if (Input.GetKey("q"))
                {
                    lookedAtInv4 = false;
                }
            }
        }
	}
}