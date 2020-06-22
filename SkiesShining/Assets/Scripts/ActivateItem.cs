public class ActivateItem
{
    private string przedmiotID;
    private string aktywujLubDeaktywuj;
    private string zmienWartoscDialogu;
    private string kontynuowacAktywacje;
    private string kolejkaAktywacjiPrzedmiotow;

    public ActivateItem(string przedmiotID, string aktywujLubDeaktywuj, string zmienWartoscDialogu, string kontynuowacAktywacje, string kolejkaAktywacjiPrzedmiotow)
    {
        this.przedmiotID = przedmiotID;
        this.aktywujLubDeaktywuj = aktywujLubDeaktywuj;
        this.zmienWartoscDialogu = zmienWartoscDialogu;
        this.kontynuowacAktywacje = kontynuowacAktywacje;
        this.kolejkaAktywacjiPrzedmiotow = kolejkaAktywacjiPrzedmiotow;
    }

    public string PrzedmiotID
    {
        get => przedmiotID;
    }
    public bool AktywujLubDeaktywuj
    {
        get
        {
            if (aktywujLubDeaktywuj.Equals("A"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public string ZmienWartoscDialogu
    {
        get => zmienWartoscDialogu;
    }
    public bool KontynuowacAktywacje
    {
        get
        {
            if (kontynuowacAktywacje.Equals("T"))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    public string KolejkaAktywacjiPrzedmiotow
    {
        get => kolejkaAktywacjiPrzedmiotow;
    }
}