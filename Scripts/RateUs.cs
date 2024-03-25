using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateUs : MonoBehaviour
{
    public void Rate()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
