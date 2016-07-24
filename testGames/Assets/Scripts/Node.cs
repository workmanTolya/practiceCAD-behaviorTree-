using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Интерфейс для узла дерева
    public interface Node {
        NodeStatus Tick(TimeData time); // Обновление времени
    }
}
