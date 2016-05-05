using UnityEngine;
using System.Collections;

public class ShipUserControl : MonoBehaviour {

	public Vector2 mouseSpeed = new Vector2(1, 1);
	public Vector2 mouseExponent = new Vector2(3, 3); //must be odd!
    public float rollSpeed = 1;

	private KeyCode fire1Key = KeyCode.Mouse0;
	private KeyCode fire2Key = KeyCode.Mouse1;
	private KeyCode backwardKey = KeyCode.S;
	private KeyCode forwardKey = KeyCode.W;

	Rigidbody shipBody;

	// Use this for initialization
	void Start () {
		shipBody = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 mousePercentage;

		mousePercentage.x = ((Input.mousePosition.x / Screen.width) * 2) - 1;
		mousePercentage.y = ((Input.mousePosition.y / Screen.height) * 2) - 1;

        float rollDistance = Input.GetAxis("Ship Roll");

		Debug.Log("mouse scroll: " + rollDistance);
	
		shipBody.AddRelativeTorque(new Vector3(-1 * Mathf.Pow(mousePercentage.y, mouseExponent.y) * mouseSpeed.y, Mathf.Pow(mousePercentage.x, mouseExponent.x) * mouseSpeed.x, rollSpeed * rollDistance));

		if(Input.GetKeyDown(forwardKey))
		{
			shipBody.AddRelativeForce(new Vector3(0, 0, 100));
		}
		else if(Input.GetKeyDown(backwardKey))
		{
			shipBody.AddRelativeForce(new Vector3(0, 0, -100));
		}
	}
}
