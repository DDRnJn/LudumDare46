using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGraph
{
    public List<Node> graph = new List<Node>();

    public Node finalNode;
    public bool computeGraph()
    {
        foreach (Node node in this.graph)
        {
            if (!(node.isRootNode))
            {
                node.inputs.Clear();
            }
        }
        foreach (Node node in this.graph)
        {
            node.setChildInput();
        }
        return finalNode.computeOutput();
    }

    public bool isFull()
    {
        foreach (Node node in this.graph)
        {
            if (node.getCurrentGate() == GateType.NONE)
            {
                return false;
            }
        }
        return true;
    }

}
