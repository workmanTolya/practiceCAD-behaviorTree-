using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Последовательность, обработка всех вложенных узлов по порядку, пока какой-либо не завершится неудачей
    public class SequenceNode : ParentNode {
        private string name;
        private List<Node> children = new List<Node>(); // Список узлов-потомков 

        public SequenceNode(string name) {
            this.name = name;
        }

        public NodeStatus Tick(TimeData time) {
            foreach (var child in children) {
                var childStatus = child.Tick(time);

                // Возвращение статуса, если обработка узла завершилась недучаей
                if (childStatus != NodeStatus.Success){
                    return childStatus;
                }
            }

            return NodeStatus.Success;
        }

        // Добавление потомка к последовательности
        public void AddChild(Node child) {
            children.Add(child);
        }
    }
}
