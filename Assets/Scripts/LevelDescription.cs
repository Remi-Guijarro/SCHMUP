using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

public class LevelDescription
{
    [XmlAttribute]
    public string Name { get; set; }

    [XmlElement("EnemyDescription", typeof(EnemyDescription))]
    public EnemyDescription[] EnemyDecription { get; set; }
}