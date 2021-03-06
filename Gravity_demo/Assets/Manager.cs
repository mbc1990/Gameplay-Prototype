using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	
	public GameObject star;
	public GameObject earth;
	public GameObject direction;
	public GameObject ghost;
	GameObject s;
	GameObject e;
	GameObject s2;
	GameObject s3;
	GameObject s4;
	GameObject s5;
	GameObject s6;
	GameObject s7;
	GameObject s8;
	
	GameObject s9;
	GameObject s10;
	GameObject s11;
	GameObject s12;
	GameObject s13;
	GameObject s14;
	GameObject s15;
	GameObject s16;
	GameObject s17;
	
	private bool in_orbit = false;
	
	private float speed = .5f;
	
	//targets set in start (these should get set by the onclick even for the star)
	private float x3;
	private float y3;
	
	
	private Vector3 target;
	private float speed_factor = 40;
	private float theta;
	private bool go = false;
	private bool leaving_orbit = false;	
	private Earth_Behavior ear;
	
	//orbit radius 
	

	// Use this for initialization
	void Start ()
	{
		//note - for finding exit point when leaving orbit, raycasting?
		
		
		//God(?)
		e = Instantiate (earth, new Vector3 (-70, -50, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		GameObject d = Instantiate (direction, new Vector3 (-70, -55, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		d.transform.parent = e.transform;
		ghost = new GameObject ();
		ghost.transform.parent = e.transform;
		ghost.transform.Translate (new Vector3 (e.transform.position.x, e.transform.position.y + .1f, e.transform.position.z));
		
		ear = e.GetComponent<Earth_Behavior> ();
		//attach ghost to earth
		ear.ghost = ghost;
		
		s = Instantiate (star, new Vector3 (-100, 80, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s2 = Instantiate (star, new Vector3 (-100, -80, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s3 = Instantiate (star, new Vector3 (-75, 45, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s4 = Instantiate (star, new Vector3 (-50, 0, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s5 = Instantiate (star, new Vector3 (0, 50, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s6 = Instantiate (star, new Vector3 (25, -75, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s7 = Instantiate (star, new Vector3 (50, -40, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s8 = Instantiate (star, new Vector3 (75, 50, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		
		s9 = Instantiate (star, new Vector3 (0, 200, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s10 = Instantiate (star, new Vector3 (-50, 250, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s11 = Instantiate (star, new Vector3 (-75, 150, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s12 = Instantiate (star, new Vector3 (25, 100, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s13 = Instantiate (star, new Vector3 (75, 180, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		
		s14 = Instantiate (star, new Vector3 (200, 0, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s15 = Instantiate (star, new Vector3 (180, -40, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s16 = Instantiate (star, new Vector3 (250, 50, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		s17 = Instantiate (star, new Vector3 (280, 50, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
		
		
		Star_Behavior sb = s.GetComponent<Star_Behavior> ();
		Star_Behavior sb2 = s2.GetComponent<Star_Behavior> ();
		Star_Behavior sb3 = s3.GetComponent<Star_Behavior> ();
		Star_Behavior sb4 = s4.GetComponent<Star_Behavior> ();
		Star_Behavior sb5 = s5.GetComponent<Star_Behavior> ();
		Star_Behavior sb6 = s6.GetComponent<Star_Behavior> ();
		Star_Behavior sb7 = s7.GetComponent<Star_Behavior> ();
		Star_Behavior sb8 = s8.GetComponent<Star_Behavior> ();
		Star_Behavior sb9 = s9.GetComponent<Star_Behavior> ();
		Star_Behavior sb10 = s10.GetComponent<Star_Behavior> ();
		Star_Behavior sb11 = s11.GetComponent<Star_Behavior> ();
		Star_Behavior sb12 = s12.GetComponent<Star_Behavior> ();
		Star_Behavior sb13 = s13.GetComponent<Star_Behavior> ();
		Star_Behavior sb14 = s14.GetComponent<Star_Behavior> ();
		Star_Behavior sb15 = s15.GetComponent<Star_Behavior> ();
		Star_Behavior sb16 = s16.GetComponent<Star_Behavior> ();
		Star_Behavior sb17 = s17.GetComponent<Star_Behavior> ();
		
		sb.earth = e;	
		sb2.earth = e;
		sb3.earth = e;
		sb4.earth = e;
		sb5.earth = e;
		sb6.earth = e;
		sb7.earth = e;
		sb8.earth = e;
		sb9.earth = e;
		sb10.earth = e;
		sb11.earth = e;
		sb12.earth = e;
		sb13.earth = e;
		sb14.earth = e;
		sb15.earth = e;
		sb16.earth = e;
		sb17.earth = e;
		
		//	e.transform.position = Vector3.Lerp (e.transform.position, Quaternion.Euler (0, 90, 0) * s.transform.position, speed * Time.deltaTime);
		/*	float hyp = Vector3.Distance (s.transform.position, e.transform.position);	
		theta = Mathf.Asin (orbit_radius / hyp);
		e.transform.LookAt(e.transform);
		
		*/
		
		/*x3 = e.transform.position.x + ((Mathf.Pow (e_const, theta) + Mathf.Pow (e_const, -1 * theta)) / 2);
		y3 = s.transform.position.y - ((Mathf.Pow (e_const, theta) + Mathf.Pow (e_const, -1 * theta)) / 2);
	
			*/
		
		//calculate lerp 
		//float hyp = Vector3.Distance (s.transform.position, e.transform.position);
		//	float theta = Mathf.Asin(orbit_radius/hyp);
		
		//what should behavior be when planet is inside orbit radius? 
		//random note: earth should gain more velocity the less their vector has to rotate to become tangent to the orbit_radius
		//and if it's going too fast for too steep a rotation, the planet should not enter orbit, but shift direction toward the system and travel past it
		//a2 = c2-b2
		//float a = Mathf.Sqrt (Mathf.Pow (hyp, 2) - Mathf.Pow (orbit_radius, 2));
	
		//better idea: don't worry about lerping to the right place - just use arcsine to find the angle, rotate e vector to point at s, then rotate angle degrees more and fly that direction
		//Stars will grab earth when it's tangential and slow enough
		
	}

	

	
	// Update is called once per frame
	void Update ()
	{
		/*	if (!in_orbit)
		{
			e.transform.Translate (0, speed * Time.deltaTime, 0);
			e.transform.position = Vector3.Lerp (e.transform.position, Quaternion.Euler (0, 90, 0) * s.transform.position, speed * Time.deltaTime);
		}
		
		*/
	
		/*	if ((Vector3.Distance (e.transform.position, s.transform.position) < ORBIT_RAD || Vector3.Distance(e.transform.position, s2.transform.position) < ORBIT_RAD) && !leaving_orbit) {
			in_orbit = true;
		}
		*/	
	//	Debug.Log ("Earth position: " + e.transform.position.ToString ());
	//	Debug.Log("Ghost position: "+ghost.transform.position.ToString());
		
		
		if (Input.anyKeyDown)
			go = !go;
		
		if (go) {
			//e.transform.Translate (0, speed * Time.deltaTime, 0);
		}
		
		if (leaving_orbit && !in_orbit) {
			e.transform.Translate (0, -1 * (speed_factor - 20) * Time.deltaTime, 0);
		}
		
		if(ear.in_orbit){
		//	Debug.Log("happening");
			Camera.main.transform.position = new Vector3(ear.current_star.transform.position.x, ear.current_star.transform.position.y, transform.position.z);
		}
		else{
		//	Debug.Log("happened");
		//	Debug.Log(ear.transform.position.x + " x, y "+ ear.transform.position.y);
			Camera.main.transform.position = new Vector3(ear.transform.position.x, ear.transform.position.y, transform.position.z);
		}
		
		
	
	}
}
