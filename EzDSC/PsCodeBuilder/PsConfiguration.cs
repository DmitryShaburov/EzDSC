using System;
using System.Collections.Generic;
using System.Linq;

namespace EzDSC
{
    public class PsConfiguration
    {
        public Guid Id;
        public HashSet<string> Servers;
        public HashSet<string> Roles;
        public Dictionary<string, string> Variables;

        public string GetId()
        {
            return Id.ToString("N").ToUpper();
        }

        public PsConfiguration(string server, HashSet<string> roles, Dictionary<string, string> variables)
        {
            Id = Guid.NewGuid();
            Servers = new HashSet<string> {server};
            Roles = roles;
            Variables = variables;
        }

        public bool IsEqual(PsConfiguration configuration)
        {
            bool rolesEqual = Roles.SetEquals(configuration.Roles);
            bool variablesEqual = (Variables.Count == configuration.Variables.Count &&
                                   !Variables.Except(configuration.Variables).Any());
            return (rolesEqual && variablesEqual);
        }

        public static PsConfiguration FindEqual(List<PsConfiguration> list, PsConfiguration configuration)
        {
            foreach (PsConfiguration listConfiguration in list)
            {
                if (listConfiguration.IsEqual(configuration))
                {
                    return listConfiguration;
                }
            }
            return null;
        }
    }
}
