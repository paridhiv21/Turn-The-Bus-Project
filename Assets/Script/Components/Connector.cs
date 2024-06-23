using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : CircuitComponent
{
    public override void InitSpiceEntity(string name, string[] interfaces, float[] parameters, string title, string description)
    {
        this.Name = name;
        this.Interfaces = interfaces;
        this.Parameters = parameters;
        this.Title = title;
        this.Description = description;
        
        spiceEntitys = new List<SpiceSharp.Entities.IEntity> ();
        spiceEntitys.Add(new SpiceSharp.Components.Resistor(name, interfaces[0], interfaces[1], 0));
    }
}
