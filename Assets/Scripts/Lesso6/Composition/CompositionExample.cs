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
            for (int i = 0; i < units.Count; i++)
            {
                var processedUnit = CompositeFactory.UnitParse(units[i].ToString());
                Debug.Log(processedUnit);
            }
        }
    }


}