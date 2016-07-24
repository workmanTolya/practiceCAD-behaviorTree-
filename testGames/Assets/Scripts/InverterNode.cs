using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Узел-декоратор, который инвертует результат потомственного узла 
    public class InverterNode : ParentNode {
        private string name; // Имя узла
        private Node childNode; // Инверитруемый потомок

        public InverterNode(string name) {
            this.name = name;
        }

        public NodeStatus Tick(TimeData time) {
            var result = childNode.Tick(time);

            // Инвертация результата в зависимости от полученного значения 
            if (result == NodeStatus.Failure) {
                return NodeStatus.Success;
            }
            else if (result == NodeStatus.Success) {
                return NodeStatus.Failure;
            }
            else{
                return result;
            }
        }

        // Добавления потомка к родительскому узлу
        public void AddChild(Node child) {
            this.childNode = child;
        }
    }
}
