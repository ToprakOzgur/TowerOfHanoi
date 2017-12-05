using System.Collections;
using UnityEngine;

public interface IRingState
{

    void UpdateState();

    void ToIdleState();

    void ToDraggableState();

    void ToReturnToOldPinState();


}
