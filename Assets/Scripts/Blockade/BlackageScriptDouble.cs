using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackageScriptDouble : BlockageScript
{
    private uint REQUIRED = 2;

    public uint OpenedCurrently = 0;

    public override void Open()
    {
        OpenedCurrently++;


        if (OpenedCurrently == REQUIRED)
        {
            base.Open();
        }
    }

    public override void Close()
    {
        OpenedCurrently--;

        if (OpenedCurrently==0)
        {
            base.Close();
        }
    }
}
