using System.IO;
using System.Linq;

namespace EzDSC
{
    internal class RepositoryWorker
    {
        private readonly DscRepository _repository;

        public RepositoryWorker(DscRepository repository)
        {
            _repository = repository;
        }

        // Create new configuration item
        public DscConfigurationItemNode NewConfigurationItemNode(string name, DscResource parent)
        {
            if (parent == null || string.IsNullOrWhiteSpace(name)) return null;

            string fileName = Path.Combine(_repository.Dir.Resources, parent.Parent.Name, parent.FriendlyName,
                name + @".json");

            DscConfigurationItem configurationItem = new DscConfigurationItem(parent);
            configurationItem.Save(fileName);
            DscConfigurationItemNode configurationItemNode = new DscConfigurationItemNode(fileName, parent);
            configurationItemNode.Validate();
            parent.Nodes.Add(configurationItemNode);

            return configurationItemNode;
        }

        // Create new role
        public DscRoleNode NewRoleNode(string name, DscRoleGroup parent)
        {
            if (parent == null || string.IsNullOrWhiteSpace(name)) return null;

            string fileName = Path.Combine(parent.DirectoryPath, name + ".json");

            DscRole role = new DscRole();
            role.Save(fileName);
            DscRoleNode roleNode = new DscRoleNode(fileName, parent);
            parent.Nodes.Add(roleNode);

            return roleNode;
        }

        // Create new roles group
        public DscRoleGroup NewRoleGroup(string name, DscRoleGroup parent)
        {
            if (parent == null || string.IsNullOrWhiteSpace(name)) return null;

            string fileName = Path.Combine(parent.DirectoryPath, name);

            FileSystem.DirectoryCreateIfNotExists(fileName);
            DscRoleGroup roleGroup = new DscRoleGroup(fileName, parent);
            parent.Groups.Add(roleGroup);

            return roleGroup;
        }

        // Create new server or server group
        public DscServerNode NewServerNode(string name, DscServerNode.ServerType type, DscServerNode parent)
        {
            if (parent == null || string.IsNullOrWhiteSpace(name)) return null;

            string fileFolder = Path.GetDirectoryName(parent.FilePath);
            if (fileFolder == null) return null;

            string fileName;
            if (type == DscServerNode.ServerType.Server)
            {
                fileName = Path.Combine(fileFolder, name + @".json");
            }
            else
            {
                fileName = Path.Combine(fileFolder, name, @".group");
                FileSystem.DirectoryCreateIfNotExists(Path.GetDirectoryName(fileName));
            }

            DscServer server = new DscServer();
            server.Save(fileName);
            DscServerNode serverNode =
                new DscServerNode(type, fileName, parent);
            parent.Nodes.Add(serverNode);

            return serverNode;
        }

        // Check if server node already contains child with provided name
        public bool Contains(string name, DscServerNode parent)
        {
            return parent != null && parent.Nodes.Any(x => x.Name == name);
        }

        // Check if roles group already contains child with provided name
        public bool Contains(string name, DscRoleGroup parent)
        {
            return (parent != null) && (parent.Nodes.Any(x => x.Name == name) || parent.Groups.Any(x => x.Name == name));
        }

        // Check if DSC resource already contains child with provided name
        public bool Contains(string name, DscResource parent)
        {
            return parent != null && parent.Nodes.Any(x => x.Name == name);
        }
    }
}
