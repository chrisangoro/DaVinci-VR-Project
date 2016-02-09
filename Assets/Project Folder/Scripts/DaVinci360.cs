using UnityEngine;
using System.Collections;

public class DaVinci360 : MonoBehaviour {

	[SerializeField] private float defaultLineLength = 70f;
	[SerializeField] private float damping = 0.5f;
	[SerializeField] private float cannonFlareVisibleTime = 0.1f;
	[SerializeField] private AudioSource cannonShotAudio;
	[SerializeField] private Transform cardboardCamera;
	[SerializeField] private Transform armoredCar;
	[SerializeField] private LineRenderer cannonFlare;
	[SerializeField] private CardboardReticle reticle;
	[SerializeField] private Particle particles;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
