
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
