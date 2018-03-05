using System;
using System.Collections.Generic;
using System.Text;

public class Humanoid
{
    protected string Id { get;private set; }

    public Humanoid() {
    }

    protected Humanoid(string id)
    {
        this.Id = id;
    }

    public bool IdEndsInText(string ending)
    {
        if (this.Id.EndsWith(ending))
            return true;
        else
            return false;
    }

    public string ReturnId()
    {
        return this.Id;
    }
}

