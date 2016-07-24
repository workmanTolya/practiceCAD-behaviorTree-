using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviourTree {
    // Структура для передачи значений времени к узлам дерева 
    public struct TimeData {
        public TimeData(float timeIncrement) {
            this.timeIncrement = timeIncrement;
        }

        public float timeIncrement;
    }
}
