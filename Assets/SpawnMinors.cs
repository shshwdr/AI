using UnityEngine;
using System.Collections;

public class SpawnMinors : MonoBehaviour {
	public GameObject minor;

	private MinorClass minorClass;
	public PublicInfo.TEAM team;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnMinor", 3, 3);
		//minorClass = GetComponent<MinorClass> ();

		team = GetComponentInParent<TeamInfo> ().team;
	}
	void SpawnMinor()
	{
		GameObject newMinor= Instantiate (minor, transform.position+transform.up, minor.transform.rotation) as GameObject;
		newMinor.GetComponent<MinorInfo> ().SetInfo ();
		newMinor.GetComponent<Team> ().team = team;
		newMinor.GetComponent<MinorMove> ().MoveTarget = GetComponentInParent<TeamInfo> ().targetBuilding;
		newMinor.GetComponent<MinorMove> ().TeamObject = gameObject.GetComponentInParent<TeamInfo> ();
		newMinor.GetComponent<astart> ().target = GetComponentInParent<TeamInfo> ().targetBuildings[0];
		newMinor.transform.parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
