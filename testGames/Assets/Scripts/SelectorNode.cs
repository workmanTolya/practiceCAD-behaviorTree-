using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Селектор, прекращает обработку, как только любой вложенный узел вернет успех
    public class SelectorNode : ParentNode {
        private string name; // Имя узла
        private List<Node> children = new List<Node>(); // Список узлов-потомков

        public SelectorNode(string name) {
            this.name = name;
        }

        public NodeStatus Tick(TimeData time) {
            foreach (var child in children) {
                var childStatus = child.Tick(time);

                // Возвращение статуса, если обработка узла не завершилась неудачей  
                if (childStatus != NodeStatus.Failure) { 
                    return childStatus;
                }
            }

            return NodeStatus.Failure;
        }

        // Добавление потомка к селектору 
        public void AddChild(Node child) {
            children.Add(child);
        }
    }
}
