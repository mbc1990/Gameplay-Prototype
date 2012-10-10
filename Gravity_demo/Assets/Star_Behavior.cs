using UnityEngine;
using System.Collections;

public class Star_Behavior : MonoBehaviour {
	
	public GameObject earth;
	
	private float orbit_radius = 15f;
	public Earth_Behavior earth_script;

	// Use this for initialization
	void Start ()
	{
		
		earth_script = earth.GetComponent<Earth_Behavior> ();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Vector3.Distance (this.transform.position, earth.transform.position) < orbit_radius && !earth_script.leaving_orbit) {
			//	Debug.Log ("in orbit");
			
			//this doesn't really fix the problem
			//	if (!earth_script.first_orbit && !earth_script.in_orbit)
			//earth.transform.Rotate (0, 0, -90);
			
			if (!earth_script.in_orbit)
			{
				earth.transform.LookAt(this.transform, new Vector3(0,1,0));
			}
			
				earth_script.in_orbit = true;
			earth_script.current_star = this.gameObject;
			
			//how to make earth rotate so that it's tangential to the orbit?
			
		}  
	}
	void OnMouseOver ()
	{
	//	Debug.Log ("mouse over star");
		
	}
	
	void OnMouseOut()
	{
	//	Debug.Log("mouse out!");
		
	}
	
	/*void OnMouseDown()
	{
		Debug.Log("clicked on star");
		
	} */
	
	
}
