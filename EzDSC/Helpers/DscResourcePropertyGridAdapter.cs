using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EzDSC
{
    internal class DscResourcePropertyGridAdapter : ICustomTypeDescriptor
    {
        readonly DscConfigurationItemNode _item;

        public DscResourcePropertyGridAdapter(DscConfigurationItemNode item)
        {
            _item = item;
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _item;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        PropertyDescriptorCollection
            ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (DictionaryEntry e in _item.ConfigurationItem.Properties)
            {
                properties.Add(new DscResourcePropertyDescriptor(_item, e.Key));
            }

            PropertyDescriptor[] props =
                (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

            return new PropertyDescriptorCollection(props);
        }
    }

    internal class DscResourcePropertyDescriptor : PropertyDescriptor
    {
        private readonly DscConfigurationItemNode _item;
        private readonly object _key;

        internal DscResourcePropertyDescriptor(DscConfigurationItemNode item, object key)
            : base(key.ToString(), null)
        {
            _item = item;
            _key = key;
        }

        public override Type PropertyType => _item.Parent.GetTypeOf(_key.ToString());

        public override TypeConverter Converter
        {
            get
            {
                List<string> values = _item.Parent.GetValuesOf(_key.ToString());
                return values != null ? new DscResourceValuesConverter(values) : base.Converter;
            }
        }

        public override void SetValue(object component, object value)
        {
            _item.ConfigurationItem.Properties[_key] = value;
        }

        public override object GetValue(object component)
        {
            return _item.ConfigurationItem.Properties[_key];
        }

        public override string Description => _item.Parent.GetDescriptionOf(_key.ToString());

        public override bool IsReadOnly => false;

        public override Type ComponentType => null;

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }

    internal class DscResourceValuesConverter : TypeConverter
    {
        private readonly List<string> _values;

        public DscResourceValuesConverter(List<string> values)
        {
            _values = values;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            // you need to get the list of values from somewhere
            // in this sample, I get it from the MyClass itself
            //var myClass = context.Instance as MyClass;
            //if (myClass != null)
            return _values != null ? new StandardValuesCollection(_values) : base.GetStandardValues(context);
        }
    }
}
