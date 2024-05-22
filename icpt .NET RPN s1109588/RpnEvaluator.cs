namespace icpt_.NET_RPN_s1109588;

public class RpnEvaluator
{
    private string RPNnotatie;
    public Stack<object> MyStack { get; set; }

    public RpnEvaluator(string rpNnotatie)
    {
        RPNnotatie = rpNnotatie;
        MyStack = new Stack<object>();
        BerekenRpn(RPNnotatie, 0);
    }

    public void BerekenRpn(string RPNnotatie, int index)
    {
        // int index = 0;
        if (RPNnotatie[index] == null)
        {
            return;
        }
        char x = RPNnotatie[index];

    }

    public void PrintString()
    {
        throw new NotImplementedException();
    }
}