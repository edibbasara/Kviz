using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdgovorScript : MonoBehaviour {
    
    public float Brzina = 10;  
    public Cvor KrajnjaPozicija;
   
  
	// Update is called once per frame
	void Update () {
        Idi();
	}
    public void Idi()
    {
        float step = Brzina * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, KrajnjaPozicija.transform.position, step);
    }
  
}
