using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Partition : MonoBehaviour {

    public List<Piste> pistes = new List<Piste>(); // une partition peut être composée de plusieurs pistes
	public int tempo { get; set; } // tempo global et accessible par toutes les pistes (en bpm)

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addPiste (Piste piste)
	{
		pistes.Add (piste);
		piste.index = pistes.Count;

	}

	public void removePiste(int index)
	{
		pistes.RemoveAt (index);
	}
	
}
