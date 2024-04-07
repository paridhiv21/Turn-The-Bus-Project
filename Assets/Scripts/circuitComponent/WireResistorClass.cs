/*
* This file was developed by a team from Carnegie Mellon University as a part of the practicum project for Fall 2022 in collaboration with Turn The Bus.
* Authors: Adrian Jenkins, Harshit Maheshwari, and Ziniu Wan. (Carnegie Mellon University)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class WireResistor : CircuitComponent
{
    public double areaOfCrossSection;
    public double resistivity;
    public double wireLength;  
    public double Resistance;
    
    public const string MATERIAL_PATH = "Materials/Resistor Materials/";
    

// Constructor to initialize the input parameters
    public void InitWireResistor(double areaOfCrossSection, double resistivity, double length)
    {
        this.areaOfCrossSection = areaOfCrossSection;
        this.resistivity = resistivity;
        this.wireLength = length;
        ComputeResistance();
    }

    public override void InitSpiceEntity(string name, string[] interfaces, float[] parameters, string title, string description)
    {
        this.Name = name;
        this.Interfaces = interfaces;
        this.Parameters = parameters;
        this.Title = title;
        this.Description = description;
        
        InitWireResistor(parameters[0], parameters[1], parameters[2]) ;
        Debug.Log(string.Format("{0} is the computed resistance of the wire", Resistance));
        this.Resistance = 10;
        Debug.Log(string.Format("{0} is the hardcoded resistance of the wire", Resistance));

        spiceEntitys = new List<SpiceSharp.Entities.IEntity>();
        spiceEntitys.Add(new SpiceSharp.Components.Resistor(name, interfaces[0], interfaces[1], Resistance));
    }

    protected override void Start()
    {
        base.Start();
        
    }

    void OnMouseDown(){
        Circuit.isLabelWindowOpen = true;
        Circuit.componentTitle = Title;
        Circuit.componentDescription = Description;
    }

    // Method to compute the resistance
    private void ComputeResistance()
    {
        // Using the formula: Resistance = (resistivity * length) / areaOfCrossSection
        this.Resistance = (this.resistivity * this.wireLength) / this.areaOfCrossSection;
    }


}
