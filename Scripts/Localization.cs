using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Localization: MonoBehaviour
{
    public static int SelectedLanguage { get; private set; }
    public static Localization Instance;
    [SerializeField] private TextAsset textFile; 
    public string Localize(string key, string param1 = "", string param2 = "", string param3 = "")
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textFile.text);
        return "";
    }
}
