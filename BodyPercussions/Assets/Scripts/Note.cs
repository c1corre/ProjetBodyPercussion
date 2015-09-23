using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public Piste piste; // piste à laquelle appartient la note
    private int index; // index dans la piste
    private float temps; // moment auquel est joué la note
    private AudioClip son; // attribut nécessaire pour jouer un son

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
