using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Allows the player to read an item.
/// </summary>

public class ReadItem : PlayerInteraction {
	
	/// <summary>
	/// The Image that holds the pages
	/// </summary>
	public GameObject pages;

	void Start()
	{
		base.Start();
	}

	protected override void Interact()
	{
		GameManager.PauseGame();
		pages.SetActive (true);
	}
}
