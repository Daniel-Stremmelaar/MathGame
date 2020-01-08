using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICannon : Cannon
{
    public override void Fire()
    {
        base.Fire();
        print("test");
    }
}
