using UnityEngine;
using System.Collections;
using VRTK;

public class PlayerStatus : MonoBehaviour {
	[SerializeField] private bool _shrunk;
	[SerializeField] private GameObject _antMan;

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
		if (_antMan != null) {
			if (!shrink) {
				_antMan.transform.localScale = new Vector3(1F, 1F, 1F);	
			} else {
				_antMan.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);	
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
