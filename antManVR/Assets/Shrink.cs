using UnityEngine;
using System.Collections;
using NewtonVR;


public class Shrink : MonoBehaviour {
	public Color LineColor;
	public float LineWidth = 0.02f;
	private PlayerStatus status;
	private LineRenderer Line;

	private NVRHand Hand;

	private void Awake()
	{
			Line = this.GetComponent<LineRenderer>();
			Hand = this.GetComponent<NVRHand>();
			status = this.GetComponentInParent<PlayerStatus>();
	Debug.Log("shrink");
			if (Line == null)
			{
					Line = this.gameObject.AddComponent<LineRenderer>();
			}

			if (Line.sharedMaterial == null)
			{
					Line.material = new Material(Shader.Find("Unlit/Color"));
					Line.material.SetColor("_Color", LineColor);
					Line.SetColors(LineColor, LineColor);
			}

			Line.useWorldSpace = true;
	}

	private void LateUpdate()
	{


			Line.enabled = (Hand != null && Hand.Inputs[Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger].SingleAxis > 0.01f);

			if (Line.enabled == true)
			{
					Line.material.SetColor("_Color", LineColor);
					Line.SetColors(LineColor, LineColor);
					Line.SetWidth(LineWidth, LineWidth);

					RaycastHit hitInfo;
					bool hit = Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 1000);
					Vector3 endPoint;

					if (hit == true)
					{
							endPoint = hitInfo.point;

							if (Hand.Inputs[Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger].PressDown == true)
							{
									NVRInteractable LHandInteractable = NVRPlayer.Instance.LeftHand.CurrentlyInteracting;
									NVRInteractable RHandInteractable = NVRPlayer.Instance.RightHand.CurrentlyInteracting;


									Vector3 offset = NVRPlayer.Instance.Head.transform.position - NVRPlayer.Instance.transform.position;
									offset.y = 0;

									NVRPlayer.Instance.transform.position = hitInfo.point - offset;
									if(!status.shrunk){
										NVRPlayer.Instance.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
										status.shrunk = true;
									}
									if (LHandInteractable != null)
									{
											LHandInteractable.transform.position = NVRPlayer.Instance.LeftHand.transform.position;
									}
									if (RHandInteractable != null)
									{
											RHandInteractable.transform.position = NVRPlayer.Instance.RightHand.transform.position;
									}
							}
					}
					{
							endPoint = this.transform.position + (this.transform.forward * 1000f);
					}

					Line.SetPositions(new Vector3[] { this.transform.position, endPoint });
			}
			else if(Hand != null && Hand.Inputs[Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad].PressDown){
				NVRInteractable LHandInteractable = NVRPlayer.Instance.LeftHand.CurrentlyInteracting;
				NVRInteractable RHandInteractable = NVRPlayer.Instance.RightHand.CurrentlyInteracting;
				if(!status.shrunk){
					NVRPlayer.Instance.transform.localScale = new Vector3(0.1F, 0.1F, 0.1F);
					status.shrunk = true;
				}
				if (LHandInteractable != null)
				{
						LHandInteractable.transform.position = NVRPlayer.Instance.LeftHand.transform.position;
				}
				if (RHandInteractable != null)
				{
						RHandInteractable.transform.position = NVRPlayer.Instance.RightHand.transform.position;
				}
			}
	}
}
