
static int PGCD(int a, int b)
{
    int c;
    int d;
    int r;

    if(a > b)
    {
        c = a;
        d = b;
    }
    else
    {
        d = a;
        c = b;
    }

    while(d != 0 && c%d != 0 && d != 1)
    {
        r = c%d;
        c = d;
        d = r;
    }

    return d;
}

static List<int> Divisors(int n)
{

    List<int> r = new List<int>();

    for(int i = 1; i < (int) Math.Sqrt(n); i++)
    {
        if(n%i == 0)
        {
            r.Add(i);
            r.Add(n/i);
        }
    }

    return r;

}
