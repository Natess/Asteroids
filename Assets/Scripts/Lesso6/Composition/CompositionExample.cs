using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Lesson6
{
    public class CompositionExample 
    {
        string parseString = "[ { \"unit\": { \"type\": \"mag\", \"health\": \"100\" }}, { \"unit\": { \"type\": \"infantry\", \"health\": \"150\" } }, { \"unit\": { \"type\": \"mag\", \"health\": \"50\" } } ]";

        public void Parse()
        {
            var units = JArray.Parse(parseString);
            foreach (var unit in units)
            {
                var processedUnit = CompositeFactory.UnitParse(unit.ToString());
                Debug.Log(processedUnit);
            }
        }
    }


}