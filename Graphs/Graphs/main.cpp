#include <iostream>
#include <string>
#include <vector>
#include "Graphs.h"
int main() {
  bool is_directed;
  int type_of_source;
  std::vector<std::vector<int>> graph;
  std::cout << "Is graph directed?(type 0 or 1)\n0. No.\n1. Yes." << std::endl;
  std::cin >> is_directed;
  std::cout << "Where will the graph be read from?(type 0 or 1)\n0. Text file.\n1. Console."
            << std::endl;
  std::cin >> type_of_source;
  if (type_of_source) {
    graph = ReadGraph(std::cin, is_directed, true);
  } else {
    std::cout << "Type the full path to the file." << std::endl;
    std::string file_path;
    std::cin >> file_path;
    std::ifstream fin(file_path);
    graph = ReadGraph(fin, is_directed, false);
  }
  MakeActionsWithGraph(is_directed, graph);
}

