namespace ANTMAN
{
	

using UnityEngine;
using System.Collections;
using VRTK;


public class Grow : MonoBehaviour {
	private PlayerStatus status;
		private void Start()
		{
			if (GetComponent<VRTK_ControllerEvents>() == null)
			{
				Debug.LogError("VRTK_ControllerEvents_ListenerExample is required to be attached to a SteamVR Controller that has the VRTK_ControllerEvents script attached to it");
				return;
			}
			if (this.GetComponentInParent<PlayerStatus>()== null)
			{
				Debug.LogError("PlayerStatus is required to be attached to the CaneraRig");
				return;
			}


			status = this.GetComponentInParent<PlayerStatus>();


			//Setup controller event listeners

			//GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
			GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoGrow);

		}

		private void DoGrow(object sender, ControllerInteractionEventArgs e){
			status.shrunk = false;
		}
		private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
		{
			Debug.Log("Controller on index '" + index + "' " + button + " has been " + action
				+ " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
		}

	}
}