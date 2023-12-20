using AoC.Common;
using AoC.Common.Math;

namespace AoC._2023;

public class Day08 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 8: Haunted Wasteland ---";

    public object PartOne(string[] input)
    {
        var instructions = input[0];
        var networkMap = new Dictionary<string, NetworkNode>();

        for (int i = 2; i < input.Length; i++)
        {
            var nodeDetails = input[i];
            var leftNode = nodeDetails.Substring(7, 3);
            var rightNode = nodeDetails.Substring(12, 3);
            var key = nodeDetails.Substring(0, 3);
            var node = new NetworkNode(key, leftNode, rightNode);
            networkMap[key] = node;
        }

        var currentNode = networkMap["AAA"];
        var stepCount = 0;

        while (currentNode.Key != "ZZZ")
        {
            foreach (var instruction in instructions)
            {
                stepCount++;
                var nextNodeKey = currentNode.GetNextNodeKey(instruction.ToString());
                currentNode = networkMap[nextNodeKey];

                if (nextNodeKey.Equals("ZZZ"))
                    break;
            }
        }

        return stepCount;
    }

    public object PartTwo(string[] input)
    {
        var instructions = input[0];
        var networkMap = new Dictionary<string, NetworkNode>();

        for (int i = 2; i < input.Length; i++)
        {
            var nodeDetails = input[i];
            var leftNode = nodeDetails.Substring(7, 3);
            var rightNode = nodeDetails.Substring(12, 3);
            var key = nodeDetails.Substring(0, 3);
            var node = new NetworkNode(key, leftNode, rightNode);
            networkMap[key] = node;
        }

        var startingNodes = networkMap.Keys
            .Where(k => k.EndsWith('A'))
            .Select(k => networkMap[k])
            .ToList();

        var stepCountMap = new Dictionary<string, long>();
        foreach (var node in startingNodes)
        {
            var currentNode = node;
            var stepCount = 0;
            while (!currentNode.Key.EndsWith('Z'))
            {
                foreach (var instruction in instructions)
                {
                    stepCount++;
                    var nextNodeKey = currentNode.GetNextNodeKey(instruction.ToString());
                    currentNode = networkMap[nextNodeKey];

                    if (currentNode.Key.EndsWith('Z'))
                    {
                        stepCountMap.Add(node.Key, stepCount);
                        break;
                    }
                }
            }
        }

        return stepCountMap.Values.LeastCommonMultiple();
    }

    private sealed class NetworkNode
    {
        private readonly string _leftNode;
        private readonly string _rightNode;
        public string Key { get; set; }

        public NetworkNode(string key, string leftNode, string rightNode)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
            Key = key;
        }

        public string GetNextNodeKey(string instruction)
        {
            return instruction.Equals("L") ? _leftNode : _rightNode;
        }
    }
}
