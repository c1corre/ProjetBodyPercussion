using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sound : MonoBehaviour {

	private AudioClip[] clipArray;
	public List<AudioClip> clips = new List<AudioClip>();
	// Use this for initialization
	void Start () {
		clipArray = Sound.LoadAll<AudioClip>("Sounds");
		foreach(AudioClip son in clipArray){
			clips.Add(son);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
