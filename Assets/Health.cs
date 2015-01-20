using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int HEALTH;
	private int health;
	// Use this for initialization
	void Start () {
		health = HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			die ();
	}
	void die(){
		Destroy (gameObject);
		if (HEALTH==20) {
			Debug.Log("building die");
			GetComponentInParent<TeamInfo>().targetBuildings.Remove(GetComponentInParent<TeamInfo>().targetBuildings[0]);
		}
	}
	void BeAttack(int hp)
	{
		Debug.Log (gameObject+ " lost health "+hp);
		health -= hp;
	}
}
