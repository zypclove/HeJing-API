using System.Collections.Generic;
using System.Linq;

namespace UltraNuke.CommonMormon.DDD
{
    public class TreeUtil
    {
        public static IList<T> Traverse<T>(IList<T> allNodes, IList<T> nodes) where T : TreeAggregateRoot<T>
        {
            foreach (var node in nodes)
            {
                var childNodes = allNodes.Where(x => x.ParentNodeId == node.Id).ToList();
                node.SetChildNodes(childNodes);
                node.SetChildNodes(Traverse(allNodes, node.ChildNodes));
            }
            return nodes;
        }
    }
}
