using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Построение дерева поведения 
namespace BehaviourTree {
    public class BehaviourTreeBuilder {
        private Stack<ParentNode> parentNodeStack = new Stack<ParentNode>(); // Используем стек для построения дерева
        private Node currentNode = null; // Последний созданный узел

        // Создание функции, которая выполняется при посещении данного узла (Action Node)
        public BehaviourTreeBuilder Do(string name, Func<TimeData, NodeStatus> action) {
            var actionNode = new ActionNode(name, action);
            parentNodeStack.Peek().AddChild(actionNode);
            return this;
        }

        // В зависимости от полученного результата получаем истину или ложь
        public BehaviourTreeBuilder IsCond(string name, Func<TimeData, bool> action) {
            return Do(name, t => action(t) ? NodeStatus.Success : NodeStatus.Failure);
        }

        // Инвертирует результат потомка 
        public BehaviourTreeBuilder Inverter(string name) {
            var inverterNode = new InverterNode(name);
            if (parentNodeStack.Count > 0){
                parentNodeStack.Peek().AddChild(inverterNode);
            }

            parentNodeStack.Push(inverterNode);
            return this;
        }

        // Создание последовательности - узлов-потомков по порядку (Sequencer)
        public BehaviourTreeBuilder Sequence(string name) {
            var sequenceNode = new SequenceNode(name);

            if (parentNodeStack.Count > 0) {
                parentNodeStack.Peek().AddChild(sequenceNode);
            }

            parentNodeStack.Push(sequenceNode);
            return this;
        }

        // Создание селектора (Selector)
        public BehaviourTreeBuilder Selector(string name) {
            var selectorNode = new SelectorNode(name);

            if (parentNodeStack.Count > 0){
                parentNodeStack.Peek().AddChild(selectorNode);
            }

            parentNodeStack.Push(selectorNode);
            return this;
        }

        // Добавление поддерева к родительскому дереву
        public BehaviourTreeBuilder Splice(Node subTree) { 
            parentNodeStack.Peek().AddChild(subTree);
            return this;
        }

        // Построение текущего дерева
        public Node Build()  {
            return currentNode;
        }

        // Завершение последовательности узлов-потомков
        public BehaviourTreeBuilder End() {
            currentNode = parentNodeStack.Pop();
            return this;
        }
    }
}
