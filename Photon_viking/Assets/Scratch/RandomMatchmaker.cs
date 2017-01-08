using UnityEngine;
using System.Collections;
using Photon;

public class RandomMatchmaker : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}

	public override void OnJoinedRoom(){
		GameObject monster = PhotonNetwork.Instantiate ("monsterprefab", Vector3.zero, Quaternion.identity, 0);
		CharacterControl controller = monster.GetComponent<CharacterControl> ();
		Debug.Log (controller.enabled);
		controller.enabled = true;
		CharacterCamera camera = monster.GetComponent<CharacterCamera> ();
		Debug.Log (camera.enabled);
		camera.enabled = true;
		//monster.GetComponent<myThirdPersonController>().isControllable = true;
	}
}
