using UnityEngine;
using System.Collections;

/// <summary>
/// A general class for player-specific interactions with objects.
/// </summary>

[RequireComponent(typeof(Collider))]
public abstract class PlayerInteraction : MonoBehaviour {

	/// <summary>
	/// The player's camera.
	/// </summary>
	protected Camera player;

	protected bool isPlayerLooking = false;

	/// <summary>
	/// The visible object is a child of this trigger.
	/// </summary>
	protected MeshRenderer visibleObject;

	/// <summary>
	/// A RaycastHit is used to check that the player is looking.
	/// </summary>
	protected RaycastHit hit;

	protected Transform myTransform;

	// Use this for initialization
	protected virtual void Start () 
	{
		if (player == null)
		{
			player = Camera.main;
		}

		Collider myColl = GetComponent<Collider>();
		if (myColl.isTrigger == false)
		{
			myColl.isTrigger = true;
		}

		myTransform = transform;
		visibleObject = GetComponentInChildren<MeshRenderer>();
	}

	/// <summary>
	/// While the player is inside the trigger area, cast a ray from the main camera
	/// to the actual object to check if they are looking at it.
	/// </summary>
	/// <param name="coll">Coll.</param>
	protected virtual void OnTriggerStay(Collider coll)
	{
		if (coll.CompareTag(GameManager.playerTag))
		{
			Vector3 playerDir = player.transform.forward;

			if(Physics.Raycast(player.transform.position, playerDir, out hit) )
			{
				Debug.DrawRay(player.transform.position, hit.point - player.transform.position, Color.yellow);
				if (hit.transform.IsChildOf(myTransform) && !isPlayerLooking)
				{
					isPlayerLooking = true;
					Highlight();
				}
				else if (!hit.transform.IsChildOf(myTransform))
				{
					isPlayerLooking = false;
					StopHighlight();
				}
			}

			if (isPlayerLooking && Input.GetButtonDown("Use"))
			{
				Interact();
			}
		}
		
	}

	protected virtual void OnTriggerExit(Collider coll)
	{
		if (coll.CompareTag(GameManager.playerTag))
		{
			StopHighlight();
		}
	}

	/// <summary>
	/// Highlight the object to let the player know they are lookng at it.
	/// </summary>
	protected void Highlight()
	{
		visibleObject.material.EnableKeyword("_EMISSION");
		visibleObject.material.SetColor ("_EmissionColor", Color.white * 0.2f);
	}

	/// <summary>
	/// Stop highlighting the object.
	/// </summary>
	protected void StopHighlight()
	{
		visibleObject.material.DisableKeyword("_EMISSION");
		visibleObject.material.SetColor("_EmissionColor", Color.clear);
	}

	protected abstract void Interact();

	protected void FreezePlayer()
	{
		player.GetComponentInParent<PlayerControl>().enabled = false;
	}

	protected void UnfreezePlayer()
	{
		player.GetComponentInParent<PlayerControl>().enabled = true;
	}

}
