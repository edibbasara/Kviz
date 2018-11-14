[System.Serializable]
public class Pitanje {
    public string Oblast;
    public string pitanje;
    public bool IsTacanOdg = false;
    public bool IsPropusten = false;
    public bool IsOdgovoren = false;
    public Odgovor[] odg;
}
