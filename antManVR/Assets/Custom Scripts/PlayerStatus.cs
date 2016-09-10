using UnityEngine;
using System.Collections;
using VRTK;

public class PlayerStatus : MonoBehaviour {
	private bool _shrunk;
	public bool shrunk {
		get { return _shrunk; }
		set{
			if (_shrunk == value)
				return;
			else
				_shrunk = value;
				this.ChangeSize(value);
		}

	}
	private void ChangeSize(bool shrink){
		GameObject antMan = GameObject.Find("PlayerObject_[CameraRig]");
		if (antMan != null) {
			if (!shrink) {
				antMan.transform.localScale = new Vector3(1F, 1F, 1F);	
			} else {
				antMan.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);	
			}
		}
		else{
			Debug.LogError ("antMan not found");
		}
	}
	// Use this for initialization
	void Start () {
		_shrunk = false;
	}

	// Update is called once per frame
	void Update () {
	}
}
