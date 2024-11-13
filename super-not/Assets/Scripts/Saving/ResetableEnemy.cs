using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class ResettableEnemy : Resettable
{
    public override void ResetHandler()
    {
        Destroy(gameObject);
    }
}
