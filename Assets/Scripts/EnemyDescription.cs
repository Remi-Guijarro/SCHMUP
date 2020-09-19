using UnityEngine;
using UnityEditor;
using System.Xml.Serialization;

[XmlRoot("EnemyDescription")]
[XmlType("EnemyDescription")]
public class EnemyDescription
{
    [XmlElement]
    public float SpawnPosition
    {
        get;
        set;
    }

    [XmlElement]
    public float SpawnDate
    {
        get;
        set;
    }
}
