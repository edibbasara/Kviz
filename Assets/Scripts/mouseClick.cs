using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouseClick : MonoBehaviour {

    public AudioClip UpitnikClick;

    // Update is called once per frame
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Pitanje")
                {
                    GetComponent<AudioSource>().PlayOneShot(UpitnikClick);
                    if(hit.collider.name == "upitnik")
                    {
                        TestPitanje.BrojPitanja = 1;
                    }else if(hit.collider.name == "upitnik(1)")
                    {
                        TestPitanje.BrojPitanja = 2;
                    }
                    else if (hit.collider.name == "upitnik(2)")
                    {
                        TestPitanje.BrojPitanja = 3;
                    }
                    else if (hit.collider.name == "upitnik(3)")
                    {
                        TestPitanje.BrojPitanja = 4;
                    }
                    else if (hit.collider.name == "upitnik(4)")
                    {
                        TestPitanje.BrojPitanja = 5;
                    }
                    else if (hit.collider.name == "upitnik(5)")
                    {
                        TestPitanje.BrojPitanja = 6;
                    }
                    else if (hit.collider.name == "upitnik(6)")
                    {
                        TestPitanje.BrojPitanja = 7;
                    }
                    else if (hit.collider.name == "upitnik(7)")
                    {
                        TestPitanje.BrojPitanja = 8;
                    }
                    else if (hit.collider.name == "upitnik(8)")
                    {
                        TestPitanje.BrojPitanja = 9;
                    }
                    else if (hit.collider.name == "upitnik(9)")
                    {
                        TestPitanje.BrojPitanja = 10;
                    }
                    else if (hit.collider.name == "upitnik(10)")
                    {
                        TestPitanje.BrojPitanja = 11;
                    }
                    else if (hit.collider.name == "upitnik(11)")
                    {
                        TestPitanje.BrojPitanja = 12;
                    }
                    else if (hit.collider.name == "upitnik(12)")
                    {
                        TestPitanje.BrojPitanja = 13;
                    }
                    else if (hit.collider.name == "upitnik(13)")
                    {
                        TestPitanje.BrojPitanja = 14;
                    }
                    else if (hit.collider.name == "upitnik(14)")
                    {
                        TestPitanje.BrojPitanja = 15;
                    }
                    else if (hit.collider.name == "upitnik(15)")
                    {
                        TestPitanje.BrojPitanja = 16;
                    }
                    
                    SceneManager.LoadScene("Level2");
                }

                               
            }

        }
    }
}
