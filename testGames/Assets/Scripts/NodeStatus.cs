using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Результаты, от которых зависит, как будут обрабатываться остальные узлы дерева 
    public enum NodeStatus {
        Success, // Успех
        Failure, // Неудача
        Running // Выполнение 
    }
}
