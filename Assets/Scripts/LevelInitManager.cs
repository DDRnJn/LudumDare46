using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelInitManager : MonoBehaviour
{
    public NodeGraph graph;

    public int levelNum;

    public List<Socket> sockets;

    public bool expectedOutput;

    public string thisLevel;

    public string nextLevel;

    public Button nextLevelButton;

    public Button retryButton;

    public Button mainMenuButton;

    public Transform levelEndCanvas;

    public Transform levelEndCanvasDefeat;

    public Transform player;

    void Awake()
    {
        Button nextButton = this.nextLevelButton.GetComponent<Button>();
        nextButton.onClick.AddListener(goToNextLevel);

        Button retry = this.retryButton.GetComponent<Button>();
        retry.onClick.AddListener(retryLevel);

        Button mainMenu = this.mainMenuButton.GetComponent<Button>();
        mainMenu.onClick.AddListener(goToMainMenu);
        if (levelNum == 1)
        {
            this.graph = createLevel1Graph();
            //Debug.Log(this.graph.graph[0].getCurrentGate());
        }
        else if (levelNum == 2)
        {
            this.graph = createLevel2Graph();
        }
        else if (levelNum == 3)
        {
            this.graph = createLevel3Graph();
        }
        else if (levelNum == 4)
        {
            this.graph = createLevel4Graph();
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

    public void endLevelVictory()
    {
        Health playerHealth = this.player.GetComponent<Health>();
        playerHealth.canTakeDamage = false;
        this.levelEndCanvas.gameObject.SetActive(true);
    }

    public void endLevelDefeat()
    {
        Health playerHealth = this.player.GetComponent<Health>();
        playerHealth.canTakeDamage = false;
        //this.player.transform.gameObject.SetActive(false);
        this.levelEndCanvasDefeat.gameObject.SetActive(true);
    }

    public void goToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void retryLevel()
    {
        SceneManager.LoadScene(thisLevel);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public bool checkInputNum(Socket socket, GateType gateType)
    {
        Node node = this.graph.getNodeFromSocket(socket);
        if (node.inputNum == 1 && gateType == GateType.NOT)
        {
            return true;
        }
        if (node.inputNum == 2 && (gateType == GateType.OR || gateType == GateType.AND))
        {
            return true;
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

        rootNode1.inputNum = 1;
        rootNode2.inputNum = 2;

        Node finalNode = new Node();

        finalNode.socket = sockets[2];
        finalNode.inputNum = 2;
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

        rootNode1.inputNum = 1;
        rootNode2.inputNum = 1;
        middleNode1.inputNum = 2;
        middleNode2.inputNum = 1;
        finalNode.inputNum = 2;

        graph.graph.Add(rootNode1);
        graph.graph.Add(rootNode2);
        graph.graph.Add(middleNode1);
        graph.graph.Add(middleNode2);
        graph.graph.Add(finalNode);

        return graph;
    }

    public NodeGraph createLevel3Graph()
    {
        NodeGraph graph = new NodeGraph();

        this.expectedOutput = true;

        Node rootNode1 = new Node();
        Node rootNode2 = new Node();
        Node rootNode3 = new Node();

        Node middleNode1 = new Node();

        Node finalNode = new Node();

        rootNode1.socket = sockets[0];
        rootNode2.socket = sockets[1];
        rootNode3.socket = sockets[2];
        middleNode1.socket = sockets[3];
        finalNode.socket = sockets[4];

        rootNode1.isRootNode = true;
        rootNode2.isRootNode = true;
        rootNode3.isRootNode = true;
        finalNode.isFinalNode = true;
        graph.finalNode = finalNode;

        rootNode1.inputs.Add(true);
        rootNode2.inputs.Add(false);
        rootNode2.inputs.Add(true);
        rootNode3.inputs.Add(false);

        rootNode1.child = middleNode1;
        rootNode2.child = middleNode1;
        rootNode3.child = finalNode;
        middleNode1.child = finalNode;

        rootNode1.inputNum = 1;
        rootNode2.inputNum = 2;
        rootNode3.inputNum = 1;
        middleNode1.inputNum = 2;
        finalNode.inputNum = 2;

        graph.graph.Add(rootNode1);
        graph.graph.Add(rootNode2);
        graph.graph.Add(rootNode3);
        graph.graph.Add(middleNode1);
        graph.graph.Add(finalNode);

        return graph;
    }

    public NodeGraph createLevel4Graph()
    {
        NodeGraph graph = new NodeGraph();

        this.expectedOutput = true;

        Node rootNode1 = new Node();
        Node rootNode2 = new Node();

        Node middleNode1 = new Node();
        Node middleNode2 = new Node();
        Node middleNode3 = new Node();

        Node finalNode = new Node();

        rootNode1.socket = sockets[0];
        rootNode2.socket = sockets[1];

        middleNode1.socket = sockets[2];
        middleNode2.socket = sockets[3];
        middleNode3.socket = sockets[4];

        finalNode.socket = sockets[5];

        rootNode1.isRootNode = true;
        rootNode2.isRootNode = true;

        finalNode.isFinalNode = true;
        graph.finalNode = finalNode;

        rootNode1.inputs.Add(true);
        rootNode1.inputs.Add(true);
        rootNode2.inputs.Add(false);
        middleNode3.fixedInputs.Add(false);

        rootNode1.child = middleNode1;
        rootNode2.child = middleNode2;
        middleNode1.child = middleNode2;
        middleNode2.child = middleNode3;
        middleNode3.child = finalNode;

        rootNode1.inputNum = 2;
        rootNode2.inputNum = 1;
        middleNode1.inputNum = 1;
        middleNode2.inputNum = 2;
        middleNode3.inputNum = 2;
        finalNode.inputNum = 1;

        graph.graph.Add(rootNode1);
        graph.graph.Add(rootNode2);
        graph.graph.Add(middleNode1);
        graph.graph.Add(middleNode2);
        graph.graph.Add(middleNode3);
        graph.graph.Add(finalNode);

        return graph;
    }
}
