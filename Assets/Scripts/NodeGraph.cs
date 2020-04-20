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
            if (node.fixedInputs.Count > 0)
            {
                foreach (bool input in node.fixedInputs)
                {
                    node.inputs.Add(input);
                }
            }
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

    public Node getNodeFromSocket(Socket socket)
    {
        foreach (Node node in this.graph)
        {
            if (node.socket == socket)
            {
                return node;
            }
        }
        return null;
    }

}
