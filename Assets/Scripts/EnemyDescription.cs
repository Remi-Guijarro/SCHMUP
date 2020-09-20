using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

[XmlRoot("EnemyDescription")]
[XmlType("EnemyDescription")]
public class EnemyDescription
{
    [XmlElement]
    public Vector2 SpawnPosition { get; set; }

    [XmlElement]
    public float SpawnDate { get; set; }

    [XmlElement]
    public string PrefabPath { get; set; }
}
