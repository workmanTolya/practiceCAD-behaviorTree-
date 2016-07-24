using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {

    // Просто некоторая функция, которая должна выполниться при посещении данного узла
    public class ActionNode : Node {
        private string name; // Имя узла
        private Func<TimeData, NodeStatus> action; // Функция для вызова действий 
        
        public ActionNode(string name, Func<TimeData, NodeStatus> action) {
            this.name=name;
            this.action=action;
        }

        public NodeStatus Tick(TimeData time) {
            return action(time);
        }
    }
}
