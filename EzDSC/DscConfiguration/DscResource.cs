using System;
using System.Collections.Generic;

namespace EzDSC
{
    public class DscResource
    {
        public enum QualifierType { Key, Required, Write, Read }
        public enum VariableType { String, Boolean, Uint32, Sint32, Uint64, Sint64, Uint16, Sint16 }
        private static readonly Dictionary<string, QualifierType> _qualifiers = new Dictionary<string, QualifierType>
        {
            {"key", QualifierType.Key},
            {"required", QualifierType.Required},
            {"write", QualifierType.Write},
            {"read", QualifierType.Read}
        };
        private static readonly Dictionary<string, VariableType> _variables = new Dictionary<string, VariableType>
        {
            {"string", VariableType.String},
            {"boolean", VariableType.Boolean},
            {"uint32", VariableType.Uint32},
            {"sint32", VariableType.Sint32},
            {"uint64", VariableType.Uint64},
            {"sint64", VariableType.Sint64},
            {"uint16", VariableType.Uint16},
            {"sint16", VariableType.Sint16}
        };

        public string ClassName;
        public string ClassVersion;
        public string FriendlyName;
        public DscModule Parent;
        public List<Parameter> Parameters = new List<Parameter>();
        public List<DscConfigurationItemNode> Nodes = new List<DscConfigurationItemNode>();

        public class Parameter
        {
            public QualifierType Qualifier;
            public VariableType Type;
            public string Name;
            public string Description;
            public string[] Values;

            public Parameter(QualifierType qualifier, VariableType type, string name, string description, string[] values)
            {
                Qualifier = qualifier;
                Type = type;
                Name = name;
                Description = description;
                Values = values;
            }

            public object GetDefaultValue()
            {
                switch (Type)
                {
                    case VariableType.String:
                        return "<REQUIRED>";
                    case VariableType.Boolean:
                        return true;
                    case VariableType.Uint16:
                    case VariableType.Uint32:
                    case VariableType.Uint64:
                    case VariableType.Sint16:
                    case VariableType.Sint32:
                    case VariableType.Sint64:
                        return 0;
                    default:
                        return "<REQUIRED>";
                }
            }
        }

        public Type GetTypeOf(string name)
        {
            Parameter parameter = Parameters.Find(x => x.Name == name);
            switch (parameter.Type)
            {
                case VariableType.String:
                    return typeof(string);
                case VariableType.Boolean:
                    return typeof(bool?);
                case VariableType.Uint16:
                    return typeof(ushort?);
                case VariableType.Uint32:
                    return typeof(uint?);
                case VariableType.Uint64:
                    return typeof(ulong?);
                case VariableType.Sint16:
                    return typeof(short?);
                case VariableType.Sint32:
                    return typeof(int?);
                case VariableType.Sint64:
                    return typeof(long?);
                default:
                    return typeof(string);
            }
        }

        public VariableType GetVariableTypeOf(string name)
        {
            Parameter parameter = Parameters.Find(x => x.Name == name);
            return parameter.Type;
        }

        public DscResource(string path, DscModule parent)
        {
            Parent = parent;
            SchemaMofFile mofFile = new SchemaMofFile(path);
            ClassName = mofFile.ClassName;
            ClassVersion = mofFile.ClassVersion;
            FriendlyName = mofFile.FriendlyName;
            foreach (SchemaMofFile.MofParameter parameter in mofFile.Parameters)
            {
                Parameters.Add(new Parameter(GetQualifierType(parameter.Qualifier), GetVariableType(parameter.Type),
                    parameter.Name, null, parameter.Values));
            }
        }

        public static QualifierType GetQualifierType(string qualifierType)
        {
            return _qualifiers[qualifierType.ToLower()];
        }

        public VariableType GetVariableType(string variableType)
        {
            return _variables[variableType.ToLower()];
        }
    }
}
