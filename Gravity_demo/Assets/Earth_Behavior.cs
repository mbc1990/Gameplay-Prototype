using UnityEngine;
using System.Collections;

public class Earth_Behavior : MonoBehaviour {
	
	public bool in_orbit;
	public GameObject current_star;
	private float speed_factor;
	//time startd orbit (for increasing speed)
	private float started_orbit;
	public bool first_orbit = true;
	public bool leaving_orbit;
	private bool go = false;
	
	private float leaving_speed;
	private float leaving_time;
	
	//constants
	private float TOP_SPEED = 150;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("In the beginning Lizard God created Lizard Heaven and Learth...");
		started_orbit = Time.time;
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		//transform.RotateAround (s.transform.position, Vector3.up, 20 * Time.deltaTime);
		if (in_orbit) {
			go = false;
			//Debug.Log ("in orbit");
			transform.RotateAround (current_star.transform.position, new Vector3 (0, 0, 1), speed_factor * Time.deltaTime);
			speed_factor = 40 + (Mathf.Pow (Time.time - started_orbit, 2) / 4);
			
			if (Input.anyKeyDown) {
				Debug.Log ("Trying to leave orbit");
				if (first_orbit)
					first_orbit = false;
				leaving_orbit = true;
				in_orbit = false;
				leaving_speed = speed_factor;
				leaving_time = Time.time;
			}
			
		} else {
			
			if (Input.anyKeyDown) {
				go = !go;
			}
			
			
			if (leaving_orbit) {
				transform.Translate (0, -1 * (speed_factor - 20) * Time.deltaTime, 0);
				
			}
			//15 should not be hard coded! stars may have different r
			if (leaving_orbit && Vector3.Distance (transform.position, current_star.transform.position) > 15f) {
				transform.Translate (0, -1 * (speed_factor - 20) * Time.deltaTime, 0);
				//turn off leaving_orbit so next star can grab planet
				leaving_orbit = false;
			}
			if (go) {
			
				transform.Translate (10 * Time.deltaTime, 0, 0);
				//	transform.position = Vector3.Lerp (transform.position, new Vector3 (-100, 0, 0), .5f * Time.deltaTime);
			} else {
				transform.Translate (0, -1 * (speed_factor - 20) * Time.deltaTime, 0);
				
			}
		}
		
		if (speed_factor < 0)
			speed_factor = 0;
		
		if (speed_factor > TOP_SPEED)
			speed_factor = TOP_SPEED;
		
		Debug.Log ("current speed factor: " + speed_factor);
		
		
		
	}
}
