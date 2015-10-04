namespace Sitecore.SharedSource.Responsive
{
    using Sitecore.Configuration;
    using Data;
    using System.Collections.Generic;
    using System.Xml;
    using Xml;

    public class Configuration
    {
        public Configuration()
        {
            var store = Factory.GetConfigNode("responsive");
            this.Fields = GetIDs(store.SelectNodes("./fields/field"));
        }

        private IEnumerable<ID> GetIDs(XmlNodeList xmlNodeList)
        {
            List<ID> ids = new List<ID>();
            foreach(XmlNode node in xmlNodeList)
            {
                ids.Add(new ID(XmlUtil.GetAttribute("id", node)));
            }

            return ids;
        }

        public IEnumerable<ID> Fields { get; private set; }
    }
}