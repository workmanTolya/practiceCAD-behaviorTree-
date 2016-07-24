using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {

    // Интерфейс для узла-родителя
    public interface ParentNode : Node {
        void AddChild(Node child); // Добавление узла-потомка 
    }
}
