using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour {

    public Pitanje[] Pitanja;
    private static List<Pitanje> ListaPitanja;
    public static List<Pitanje> TrenutnaPitanja;
    public static List<Pitanje> tempList;
    public static int OdgovorBr;
    public static int PitanjeBr;
    
    public Text timerText;
    public Text BodoviText;
    public Text OblastText;
    public static int bodoviDefault = 5;
    public static int rezultat = 0;
    public static float secondsCount=0;
    public static int minuteCount = 0;
    public static bool IsStartGame = true;
    public static bool IsUpitnikStart = true;
    

    void Start()
    {
        if (IsStartGame == true)
        {
            TrenutnaPitanja = new List<Pitanje>();

            if (ListaPitanja == null || ListaPitanja.Count == 0)
            {
                ListaPitanja = Pitanja.ToList<Pitanje>();
            }
            if(TrenutnaPitanja != null || TrenutnaPitanja.Count != 0)
            {
                TrenutnaPitanja.Clear();
                OdgovorBr = 0;
                PitanjeBr = 0;
            }

            GetRandomPitanje();
            
            IsStartGame = false;
        }
    }

    void Update()
    {
        UpdateTimerUI();
        SetBodovi();
    }

    private void SetBodovi()
    {
        OblastText.text = TrenutnaPitanja[0].Oblast;
        BodoviText.text = rezultat.ToString();
    }
    
    private void GetRandomPitanje()
    {        
        if (GameMenu.IsMatematika)
        {
            tempList = ListaPitanja.Where(x => x.Oblast == "Matematika").ToList();
            
        }else if (GameMenu.IsPriroda)
        {
            tempList = ListaPitanja.Where(x => x.Oblast == "Priroda").ToList();
        }
        else if(GameMenu.IsInformatika)
        {
            tempList = ListaPitanja.Where(x => x.Oblast == "Informatika").ToList();
        }
        if (tempList.Count != 0)
        {
            
            for(int i= 0; i< 16;i++)
            {
                int RandomIndex = UnityEngine.Random.Range(0, tempList.Count);               
                TrenutnaPitanja.Add(tempList[RandomIndex]);
                tempList.RemoveAt(RandomIndex);
            }                  
        }
        
    }
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
    }
}
