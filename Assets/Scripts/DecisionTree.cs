using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecisionTree : ScriptableObject
{
    
}

public class DTNode : ScriptableObject
{
    public List<DTNode> children = new List<DTNode>();

    public virtual bool eval () {
        return false;
    }

    protected virtual void execute () {
        
    }

    public virtual bool Step () {
        return false;
    }
}

public class DTOr : DTNode
{
    List<DTNode> children = new List<DTNode>();

    public override bool eval () {
        return !(children.TrueForAll(dtnode => !dtnode.eval()));
    }

    public override bool Step () {
        bool result = eval();

         if (result) {
             execute();
             bool success = false;

            foreach (DTNode n in children) {
                if (!success) {
                    success = n.Step();
                }    
            }
         }
         return result;
    }
}

public class DTAnd : DTNode
{
    List<DTNode> children = new List<DTNode>();

    public override bool eval () {
        return !(children.TrueForAll(dtnode => !dtnode.eval()));
    }

    public override bool Step () {
        bool result = eval();

         if (result) {
             bool keepGoing = true;

            foreach (DTNode n in children) {
                if (keepGoing) {
                    keepGoing = n.Step();
                }    
            }
         }
         return result;
    }
}