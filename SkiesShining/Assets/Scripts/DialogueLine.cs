public class DialogueLine
{
    private string dialog;
    private string przedmiot;
    private string nagranie;
    private string zmianaWartosci;
    private string kontynuowacDialog;
    private string aktywowacInne;
    private string dialogCzyTekst;
    private string indeksWyboru;

    public DialogueLine(string dialog, string przedmiot, string nagranie, string zmianawartosci, string kontynuowac, string aktywowacInne, string dialogCzyTekst, string indeksWyboru)
    {
        this.dialog = dialog;
        this.przedmiot = przedmiot;
        this.nagranie = nagranie;
        this.zmianaWartosci = zmianawartosci;
        this.kontynuowacDialog = kontynuowac;
        this.aktywowacInne = aktywowacInne;
        this.dialogCzyTekst = dialogCzyTekst;
        this.indeksWyboru = indeksWyboru;
    }

    public string Dialog
    {
        get => dialog;
    }
    public string Przedmiot
    {
        get => przedmiot;
    }
    public string Nagranie
    {
        get => nagranie;
    }
    public string ZmianaWartosci
    {
        get => zmianaWartosci;
    }
    public bool Kontynuowac
    {
        get
        {
            if (kontynuowacDialog.Equals("T"))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    public string AktywowacInne
    {
        get => aktywowacInne;
    }
    public bool DialogCzyTekst
    {
        get
        {
            if (dialogCzyTekst.Equals("D"))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
    public string IndeksWyboru
    {
        get => indeksWyboru;
    }
}