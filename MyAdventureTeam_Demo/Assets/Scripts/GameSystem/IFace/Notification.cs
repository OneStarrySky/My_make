using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification
{
    public object[] obj;

    public Notification(params object[] obj)
    {
        this.obj = obj;
    }
}
