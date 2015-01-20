using UnityEngine;
using System.Collections;

public class MinorAI : MonoBehaviour {
	public float attackRange;
	public float seeRange;

	private MinorInfo info;
	// Use this for initialization
	void Start () {
		info = GetComponent<MinorInfo> ();
	}
	
	// Update is called once per frame
	void Update () {
		Collider[] attackable= Physics.OverlapSphere (transform.position, attackRange);
		Collider[] seeable= Physics.OverlapSphere (transform.position, seeRange);
		foreach (Collider col in seeable) {
			if(col.GetComponent<Team>()!=null&&col.GetComponent<Team>().team!=GetComponent<Team>().team)
			{
				Debug.Log(gameObject+" see "+col.gameObject);
				GetComponent<astart>().target=col.gameObject;
				GetComponent<astart>().ReDirect();
				break;

			}
		}
		foreach (Collider col in attackable) {
			if(col.GetComponent<Team>()!=null&&col.GetComponent<Team>().team!=GetComponent<Team>().team)
			{
				GetComponent<MinorMove>().onMove=false;
				Debug.Log("stop");
				Attack(col.gameObject);
				break;

			}
		}
	}
	void Attack(GameObject obj)
	{
		obj.SendMessage ("BeAttack",info.attack, SendMessageOptions.DontRequireReceiver);
	}
}
