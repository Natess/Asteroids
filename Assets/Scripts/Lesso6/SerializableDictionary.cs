using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Lesson6
{
    public class SerializableDictionary : MonoBehaviour, ISerializationCallbackReceiver
    {
        public List<int> Keys = new List<int> { 3, 4, 5 };
        public List<string> Values = new List<string> { "apple", "lemon", "banana" };

        public Dictionary<int, string> CustomDictionary = new Dictionary<int, string>();

        public void OnBeforeSerialize()
        {
            Keys.Clear();
            Values.Clear();

            foreach (var kvp in CustomDictionary)
            {
                Keys.Add(kvp.Key);
                Values.Add(kvp.Value);
            }
        }
        public void OnAfterDeserialize()
        {
            CustomDictionary = new Dictionary<int, string>();

            for (int i = 0; i != Math.Min(Keys.Count, Values.Count); i++)
                CustomDictionary.Add(Keys[i], Values[i]);
        }


        void OnGUI()
        {
            foreach (var item in CustomDictionary)
                GUILayout.Label("Key: " + item.Key + " value: " + item.Value);
        }
    }
}