public class Decision
{
    private string tekstDecyzji;
    private string wymogiWsparcia;
    private string indeksWplywuNaInne;
    private string nastepnaDecyzja;

    public Decision (string tekstDecyzji, string wymogiWsparcia, string indeksWplywuNaInne, string nastepnaDecyzja)
    {
        this.tekstDecyzji = tekstDecyzji;
        this.wymogiWsparcia = wymogiWsparcia;
        this.indeksWplywuNaInne = indeksWplywuNaInne;
        this.nastepnaDecyzja = nastepnaDecyzja;
    }

    public string TekstDecyzji
    {
        get => tekstDecyzji;
    }
    public string WymogiWsparcia
    {
        get => wymogiWsparcia;
    }
    public string IndeksWplywuNaInne
    {
        get => indeksWplywuNaInne;
    }
    public string NastepnaDecyzja
    {
        get => nastepnaDecyzja;
    }
}