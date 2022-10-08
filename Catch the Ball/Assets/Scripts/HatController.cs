using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        { // Ako nije, inicijalizira se 
            cam = Camera.main; 
        }
    }

    void FixedUpdate()
    { // Dohvat pozicije kursora miša na ekranu 
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition); 
        // Izracun pozicije u koju ce objekt ici 
        // Uzima se samo pozicija kursora na x osi jer se objekt
        // moze samo tako pomicati 
        Vector3 targetPosition = new Vector3(rawPosition.x, transform.position.y, 0.0f); 
        // Pomicanje objekta 
        GetComponent<Rigidbody2D>().MovePosition(targetPosition); 
    }
}
