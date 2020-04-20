using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Socket socket;

    public List<bool> inputs = new List<bool>();

    public List<bool> fixedInputs = new List<bool>();

    public Node child;

    public bool isRootNode = false;

    public bool isFinalNode = false;

    public int inputNum;

    public GateType getCurrentGate()
    {
        if (socket)
        {
            if (!(socket.empty))
            {
                LogicGatePlayer logicGatePlayer = this.socket.currentLogicGate.GetComponent<LogicGatePlayer>();
                GateType gateType = logicGatePlayer.gateType;
                return gateType;
            }
        }
        return GateType.NONE;
    }

    public bool computeOutput()
    {
        if (this.inputs.Count == 1 && this.getCurrentGate() == GateType.NOT)
        {
            return !(this.inputs[0]);
        }
        if (this.inputs.Count == 2)
        {
            bool input1 = this.inputs[0];
            bool input2 = this.inputs[1];
            if (this.getCurrentGate() == GateType.OR)
            {
                return (input1 | input2);
            }
            else if (this.getCurrentGate() == GateType.AND)
            {
                return (input1 & input2);
            }
        }
        return false; // Should never get here
    }

    public void setChildInput()
    {
        if (!(isFinalNode))
        {
            child.inputs.Add(this.computeOutput());
        }
    }
}
