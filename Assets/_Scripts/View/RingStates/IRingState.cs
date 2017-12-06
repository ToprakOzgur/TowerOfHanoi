using System.Collections;
using UnityEngine;

// FOR STATE DESIGN PATTERN 
public interface IRingState
{

    void UpdateState();

    void ToIdleState();

    void ToDraggableState();

    void ToReturnToOldPinState();

    void ToControlPinState();

    void OnCollisionStay2D(Collision2D collision);

}
