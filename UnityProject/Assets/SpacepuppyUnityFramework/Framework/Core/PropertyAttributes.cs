﻿using UnityEngine;

using com.spacepuppy.Utils;

namespace com.spacepuppy
{

    public abstract class SPPropertyAttribute : PropertyAttribute
    {

        public SPPropertyAttribute()
        {

        }

    }

    #region ComponentAttributes

    public abstract class ComponentHeaderAttribute : PropertyAttribute
    {

    }

    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ConstantlyRepaintEditorAttribute : System.Attribute
    {
        public bool RuntimeOnly;
    }

    #endregion

    #region Property Drawer Attributes

    /// <summary>
    /// Restrict a value to be no greater than max.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class MaxRangeAttribute : SPPropertyAttribute
    {
        public float Max;

        public MaxRangeAttribute(float max)
        {
            this.Max = max;
        }
    }

    /// <summary>
    /// Restrict a value to be no lesser than min.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class MinRangeAttribute : SPPropertyAttribute
    {
        public float Min;

        public MinRangeAttribute(float min)
        {
            this.Min = min;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class OneOrManyAttribute : SPPropertyAttribute
    {
        public OneOrManyAttribute()
        {

        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class ReorderableArrayAttribute : SPPropertyAttribute
    {

        public string ElementLabelFormatString = null;
        public bool DisallowFoldout;
        public bool RemoveBackgroundWhenCollapsed;
        public bool Draggable = true;
        public float ElementPadding = 0f;
        public bool DrawElementAtBottom = false;
        public bool HideElementLabel = false;
        public bool ShowTooltipInHeader = false;

        /// <summary>
        /// If DrawElementAtBottom is true, this child element can be displayed as the label in the reorderable list.
        /// </summary>
        public string ChildPropertyToDrawAsElementLabel;

        /// <summary>
        /// If DrawElementAtBottom is true, this child element can be displayed as the modifiable entry in the reorderable list.
        /// </summary>
        public string ChildPropertyToDrawAsElementEntry;

        /// <summary>
        /// A method on the serialized object that is called when a new entry is added to the list/array. Should accept the list member type 
        /// as a parameter, and then also return it (used for updating).
        /// 
        /// Like:
        /// object OnObjectAddedToList(object obj)
        /// </summary>
        public string OnAddCallback;

        /// <summary>
        /// If the array/list accepts UnityEngine.Objects, this will allow the dragging of objects onto the inspector to auto add without needing to click the + button.
        /// </summary>
        public bool AllowDragAndDrop = true;

        public ReorderableArrayAttribute()
        {

        }

    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class SelectableComponentAttribute : SPPropertyAttribute
    {
        public System.Type InheritsFromType;
        public bool AllowSceneObjects = true;
        public bool ForceOnlySelf = false;
        public bool SearchChildren = false;
        public bool AllowProxy;

        public SelectableComponentAttribute()
        {

        }

        public SelectableComponentAttribute(System.Type inheritsFromType)
        {
            this.InheritsFromType = inheritsFromType;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class SelectableObjectAttribute : SPPropertyAttribute
    {
        public System.Type InheritsFromType;
        public bool AllowSceneObjects = true;
        public bool AllowProxy;

        public SelectableObjectAttribute()
        {

        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class TimeUnitsSelectorAttribute : SPPropertyAttribute
    {
        public string DefaultUnits;

        public TimeUnitsSelectorAttribute()
        {
        }

        public TimeUnitsSelectorAttribute(string defaultUnits)
        {
            DefaultUnits = defaultUnits;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class TypeRestrictionAttribute : SPPropertyAttribute
    {
        public System.Type InheritsFromType;
        public bool HideTypeDropDown;
        public bool AllowProxy;

        public TypeRestrictionAttribute(System.Type inheritsFromType)
        {
            this.InheritsFromType = inheritsFromType;
        }

    }

    /// <summary>
    /// A specialized PropertyDrawer that draws a struct/class in the shape:
    /// struct Pair
    /// {
    ///     float Weight;
    ///     UnityEngine.Object Value;
    /// }
    /// 
    /// It is drawn in the inspector as a single row as weight : value. 
    /// It is intended for use with arrays/lists of values that can be randomly selected by some weight.
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class WeightedValueCollectionAttribute : ReorderableArrayAttribute
    {
        public string WeightPropertyName = "Weight";

        public WeightedValueCollectionAttribute(string weightPropName, string valuePropName)
        {
            this.WeightPropertyName = weightPropName;
            this.ChildPropertyToDrawAsElementEntry = valuePropName;
        }
    }

    #endregion

    #region ModifierDrawer Attributes

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public abstract class PropertyModifierAttribute : SPPropertyAttribute
    {
        public bool IncludeChidrenOnDraw;
    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class DisableOnPlayAttribute : PropertyModifierAttribute
    {

    }

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = false)]
    public class OnChangedInEditorAttribute : PropertyModifierAttribute
    {

        public readonly string MethodName;
        public bool OnlyAtRuntime;

        public OnChangedInEditorAttribute(string methodName)
        {
            this.MethodName = methodName;
        }

    }

    #endregion

    #region NonSerialized Property Drawer Attributes

    public class ShowNonSerializedPropertyAttribute : System.Attribute
    {
        public string Label;
        public string Tooltip;
        public bool Readonly;

        public ShowNonSerializedPropertyAttribute(string label)
        {
            this.Label = label;
        }
    }

    #endregion

}