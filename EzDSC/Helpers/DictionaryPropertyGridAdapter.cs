using System;
using System.Collections;
using System.ComponentModel;

namespace EzDSC
{
    internal class DictionaryPropertyGridAdapter : ICustomTypeDescriptor
    {
        readonly IDictionary _dictionary;
        readonly DscResource _schema;

        public DictionaryPropertyGridAdapter(IDictionary d, DscResource s)
        {
            _dictionary = d;
            _schema = s;
        }

        public DictionaryPropertyGridAdapter(IDictionary d)
        {
            _dictionary = d;
            _schema = null;
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
            return _dictionary;
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
            foreach (DictionaryEntry e in _dictionary)
            {
                properties.Add(_schema != null
                    ? new DictionaryPropertyDescriptor(_dictionary, e.Key, _schema)
                    : new DictionaryPropertyDescriptor(_dictionary, e.Key));
            }

            PropertyDescriptor[] props =
                (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

            return new PropertyDescriptorCollection(props);
        }
    }

    class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        readonly IDictionary _dictionary;
        readonly object _key;
        readonly DscResource _schema;

        internal DictionaryPropertyDescriptor(IDictionary d, object key, DscResource s)
            : base(key.ToString(), null)
        {
            _dictionary = d;
            _key = key;
            _schema = s;
        }

        internal DictionaryPropertyDescriptor(IDictionary d, object key)
            : base(key.ToString(), null)
        {
            _dictionary = d;
            _key = key;
            _schema = null;
        }

        public override Type PropertyType
        {
            get
            {
                if (_schema != null)
                {
                    return _schema.GetTypeOf(_key.ToString());
                }
                else
                {
                    return _dictionary[_key].GetType();
                }
            }
        }

        public override void SetValue(object component, object value)
        {
            _dictionary[_key] = value;
        }

        public override object GetValue(object component)
        {
            return _dictionary[_key];
        }

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
}
