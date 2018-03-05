using System;
using System.Collections.Generic;
using System.Text;

public interface IBuyer:IPerson
{
    int Food { get; set; }

    void BuyFood();
}

