﻿using System.Xml.Serialization;

namespace DnDLookup.dto.fc5
{
    // ReSharper disable once InconsistentNaming
    public class FC5Feat
    {
        [XmlElement("name")] public string[] Name { get; set; }
    }
}