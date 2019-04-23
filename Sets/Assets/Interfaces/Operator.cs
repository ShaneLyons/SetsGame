using System.Collections.Generic;

public interface Operator
{
    //set is the set being inputted, leftInput is whether the input is coming from the left input or not
    //takes in the input set, updates the internal set, and outputs the value
    void InputSet(HashSet<Jewel> set, bool leftInput);
}
