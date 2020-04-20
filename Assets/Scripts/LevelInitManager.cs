using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitManager : MonoBehaviour
{
    public NodeGraph graph;

    public int levelNum;

    public List<Socket> sockets;

    public bool expectedOutput;

    void Awake()
    {
        if (levelNum == 1)
        {
            this.graph = createLevel1Graph();
            //Debug.Log(this.graph.graph[0].getCurrentGate());
        }
        else if (levelNum == 2)
        {
            this.graph = createLevel2Graph();
        }
    }

    public bool checkIfLevelComplete()
    {
        if (this.graph.isFull())
        {
            return this.graph.computeGraph() == this.expectedOutput;
        }
        return false;
    }

    public NodeGraph createLevel1Graph()
    {
        NodeGraph graph = new NodeGraph();

        this.expectedOutput = true;

        Node rootNode1 = new Node();
        Node rootNode2 = new Node();

        rootNode1.isRootNode = true;
        rootNode2.isRootNode = true;

        rootNode1.socket = sockets[0];
        rootNode2.socket = sockets[1];

        rootNode1.inputs.Add(true);
        rootNode2.inputs.Add(true);
        rootNode2.inputs.Add(true);

        Node finalNode = new Node();

        finalNode.socket = sockets[2];
        finalNode.isFinalNode = true;
        graph.finalNode = finalNode;

        rootNode1.child = finalNode;
        rootNode2.child = finalNode;

        graph.graph.Add(rootNode1);
        graph.graph.Add(rootNode2);
        graph.graph.Add(finalNode);

        return graph;
    }

    public NodeGraph createLevel2Graph()
    {
        NodeGraph graph = new NodeGraph();

        this.expectedOutput = false;

        Node rootNode1 = new Node();
        Node rootNode2 = new Node();

        Node middleNode1 = new Node();
        Node middleNode2 = new Node();

        Node finalNode = new Node();

        rootNode1.socket = sockets[0];
        rootNode2.socket = sockets[1];

        middleNode1.socket = sockets[2];
        middleNode2.socket = sockets[3];

        finalNode.socket = sockets[4];

        rootNode1.isRootNode = true;
        rootNode2.isRootNode = true;

        rootNode1.inputs.Add(true);
        rootNode2.inputs.Add(false);

        middleNode1.fixedInputs.Add(false);

        rootNode1.child = middleNode1;
        rootNode2.child = middleNode2;

        middleNode1.child = finalNode;
        middleNode2.child = finalNode;

        finalNode.isFinalNode = true;
        graph.finalNode = finalNode;

        graph.graph.Add(rootNode1);
        graph.graph.Add(rootNode2);
        graph.graph.Add(middleNode1);
        graph.graph.Add(middleNode2);
        graph.graph.Add(finalNode);

        return graph;
    }
}
