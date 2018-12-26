using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
[CustomPropertyDrawer(typeof(RangeProperty))]
public class AccessPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginChangeCheck();
        RangeProperty rp = attribute as RangeProperty;
        EditorGUI.Slider(position, property, rp.min, rp.max);
        if (EditorGUI.EndChangeCheck())
        {
            rp.dirty = true;
        }
        else if (rp.dirty)
        {
            object obj = property.serializedObject.targetObject;
            Type type = obj.GetType();
            PropertyInfo pi = type.GetProperty(rp.propertyName);
            if (pi != null)
            {
                pi.SetValue(obj, fieldInfo.GetValue(obj), null);
            }
            else
            {
                Debug.LogError("Invalid property name: " + rp.propertyName + "\nCheck your [RangeProperty] attribute!");
            }
            rp.dirty = false;
        }
    }
}
