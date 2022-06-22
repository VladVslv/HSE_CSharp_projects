#include "Graphs.h"
void MakeActionsWithGraph(bool is_directed, const std::vector<std::vector<int>> &graph) {
  bool need_to_continue = true;
  while (need_to_continue) {
    std::cout << "What action with the graph do you want to do?(type 0 or 1 or 2)"
                 "\n0. Vertex degree counting for an undirected graph and "
                 "half-degrees of vertices for a directed graph."
                 "\n1. Counting the number of edges (for undirected)/arcs (for "
                 "oriented) graph."
                 "\n2. Displaying the graph in a different view." << std::endl;
    int type_of_command;
    int type_of_source;
    std::cin >> type_of_command;
    switch (type_of_command) {
      case 0:CountDegrees(graph, is_directed);
        break;
      case 1:CountEdges(graph, is_directed);
        break;
      default:
        std::cout << "Where will the graph be written?(type 0 or 1)\n0. Text file.\n1. Console."
                  << std::endl;
        std::cin >> type_of_source;
        if (type_of_source) {
          WriteGraph(std::cout, graph, is_directed);
        } else {
          std::cout << "Type the full path to the file." << std::endl;
          std::string file_path;
          std::cin >> file_path;
          std::ofstream fout(file_path);
          WriteGraph(fout, graph, is_directed);
        }
        break;
    }
    std::cout << "Type 0 to finish the program or 1 to continue." << std::endl;
    std::cin >> need_to_continue;
  }
}
std::vector<std::vector<int>> ReadGraph(std::istream &is, bool is_directed, bool is_from_console) {
  std::cout << "In what form is the graph saved?(type 0 or 1 or 2 or 3)"
               "\n0. Adjacency matrix."
               "\n1. Incidence matrix."
               "\n2. Adjacency list."
               "\n3. List of edges." << std::endl;
  int type_of_graph;
  std::cin >> type_of_graph;
  if (is_from_console) {
    std::cout << "Enter the graph.\n";
  }
  switch (type_of_graph) {
    case 0:return ReadAdjacencyMatrix(is);
    case 1:return ReadIncidenceMatrix(is, is_directed);
    case 2:return ReadAdjacencyList(is);
    default:return ReadListOfEdges(is, is_directed);
  }
}
std::vector<std::vector<int>> ReadAdjacencyMatrix(std::istream &is) {
  std::vector<std::vector<int>> adjacency_matrix;
  std::string next_line;
  std::vector<int> next_vertex_info;
  int next_num;
  int number_of_vertices;
  is >> number_of_vertices;
  std::getline(is, next_line);
  for (int i = 0; i < number_of_vertices; ++i) {
    std::getline(is, next_line);
    std::stringstream sstream(next_line);
    while (sstream >> next_num) {
      next_vertex_info.push_back(next_num);
    }
    adjacency_matrix.push_back(next_vertex_info);
    next_vertex_info = {};
  }
  return adjacency_matrix;
}
std::vector<std::vector<int>> ReadIncidenceMatrix(std::istream &is, bool is_directed) {
  std::vector<std::vector<int>> incidence_matrix;
  std::string next_line;
  std::vector<int> next_line_info;
  int next_num;
  int number_of_vertices;
  is >> number_of_vertices;
  std::getline(is, next_line);
  for (int i = 0; i < number_of_vertices; ++i) {
    std::getline(is, next_line);
    std::stringstream sstream(next_line);
    while (sstream >> next_num) {
      next_line_info.push_back(next_num);
    }
    incidence_matrix.push_back(next_line_info);
    next_line_info = {};
  }
  std::vector<std::vector<int>> adjadjacency_matrix(incidence_matrix.size(),
                                                    std::vector<int>(incidence_matrix.size(), 0));
  if (incidence_matrix.empty()) {
    return {};
  } else {
    if (!is_directed) {
      for (auto i = 0; i < incidence_matrix[0].size(); ++i) {
        int start_vertex = 0;
        int end_vertex = 0;
        while (!(start_vertex != end_vertex && incidence_matrix[start_vertex][i] == 1
            && incidence_matrix[end_vertex][i] == 1)) {
          if (incidence_matrix[start_vertex][i] != 1) {
            ++start_vertex;
            ++end_vertex;
          } else {
            ++end_vertex;
          }
        }
        adjadjacency_matrix[start_vertex][end_vertex] = 1;
        adjadjacency_matrix[end_vertex][start_vertex] = 1;
      }
    } else {
      for (auto i = 0; i < incidence_matrix[0].size(); ++i) {
        int start_vertex = 0;
        int end_vertex = 0;
        while (incidence_matrix[start_vertex][i] != -1 || incidence_matrix[end_vertex][i] != 1) {
          if (incidence_matrix[start_vertex][i] != -1) {
            ++start_vertex;
          } else {
            ++end_vertex;
          }
        }
        adjadjacency_matrix[start_vertex][end_vertex] = 1;
      }
    }
  }
  return adjadjacency_matrix;
}
std::vector<std::vector<int>> ReadAdjacencyList(std::istream &is) {
  std::vector<std::vector<int>> adjacency_list;
  std::string next_line;
  std::vector<int> next_line_info;
  int next_num;
  int number_of_vertices;
  is >> number_of_vertices;
  std::getline(is, next_line);
  for (int i = 0; i < number_of_vertices; ++i) {
    std::getline(is, next_line);
    std::stringstream sstream(next_line);
    while (sstream >> next_num) {
      next_line_info.push_back(next_num);
    }
    adjacency_list.push_back(next_line_info);
    next_line_info = {};
  }
  std::vector<std::vector<int>> adjadjacency_matrix;
  adjadjacency_matrix.resize(adjacency_list.size(), std::vector<int>(adjacency_list.size(), 0));
  for (auto start_vertex = 0; start_vertex < adjacency_list.size(); ++start_vertex) {
    for (auto end_vertex : adjacency_list[start_vertex]) {
      adjadjacency_matrix[start_vertex][end_vertex] = 1;
    }
  }
  return adjadjacency_matrix;
}
std::vector<std::vector<int>> ReadListOfEdges(std::istream &is, bool is_directed) {
  int number_of_vertices, number_of_edges;
  is >> number_of_vertices;
  is >> number_of_edges;
  std::vector<std::vector<int>> adjadjacency_matrix;
  adjadjacency_matrix.resize(number_of_vertices, std::vector<int>(number_of_vertices, 0));
  std::vector<std::vector<int>> adjacency_list;
  std::string next_line;
  int start_vertex, end_vertex;
  if (is_directed) {
    std::getline(is, next_line);
    for (int i = 0; i < number_of_edges; ++i) {
      std::getline(is, next_line);
      std::stringstream sstream(next_line);
      sstream >> start_vertex >> end_vertex;
      adjadjacency_matrix[start_vertex][end_vertex] = 1;
    }
  } else {
    std::getline(is, next_line);
    for (int i = 0; i < number_of_edges; ++i) {
      std::getline(is, next_line);
      std::stringstream sstream(next_line);
      sstream >> start_vertex >> end_vertex;
      adjadjacency_matrix[start_vertex][end_vertex] = 1;
      adjadjacency_matrix[end_vertex][start_vertex] = 1;
    }
  }
  return adjadjacency_matrix;
}
void CountDegrees(const std::vector<std::vector<int>> &graph, bool is_directed) {
  if (!is_directed) {
    int degree;
    std::cout << "Degress of the vertices (in the form <number_of_vertex> : <degree>):"
              << std::endl;
    for (auto edges_from_one_vertex = graph.begin();
         edges_from_one_vertex != graph.end(); ++edges_from_one_vertex) {
      degree = 0;
      for (int is_edge : *edges_from_one_vertex) {
        degree += is_edge;
      }
      std::cout << edges_from_one_vertex - graph.begin() << " : " << degree << std::endl;
    }
  } else {
    std::cout
        << "Degress of the vertices (in the form <number_of_vertex> : <in_degree> , <out_degree>):"
        << std::endl;
    std::vector<std::pair<int, int>> degrees_of_vertices;
    degrees_of_vertices.resize(size(graph), {0, 0});
    for (auto current_start_vertex = 0; current_start_vertex < graph.size();
         ++current_start_vertex) {
      for (auto current_end_vertex = 0; current_end_vertex < graph.size(); ++current_end_vertex) {
        degrees_of_vertices[current_start_vertex].second +=
            graph[current_start_vertex][current_end_vertex];
        degrees_of_vertices[current_end_vertex].first +=
            graph[current_start_vertex][current_end_vertex];
      }
    }
    for (auto number_of_vertex = 0; number_of_vertex < graph.size(); ++number_of_vertex) {
      std::cout << number_of_vertex << " : " << degrees_of_vertices[number_of_vertex].first
                << " , " << degrees_of_vertices[number_of_vertex].second << "\n";
    }
  }
}
void CountEdges(const std::vector<std::vector<int>> &graph, bool is_directed) {
  int number_of_edges = 0;
  for (const std::vector<int> &edges_from_one_vertex : graph) {
    for (int is_edge : edges_from_one_vertex) {
      number_of_edges += is_edge;
    }
  }
  if (!is_directed) {
    number_of_edges /= 2;
  }
  std::cout << number_of_edges << std::endl;
}
void WriteGraph(std::ostream &os, const std::vector<std::vector<int>> &graph, bool is_directed) {
  std::cout << "In what form will the graph be written?(type 0 or 1 or 2 or 3)"
               "\n0. Adjacency matrix."
               "\n1. Incidence matrix."
               "\n2. Adjacency list."
               "\n3. List of edges" << std::endl;
  int type_of_graph;
  std::cin >> type_of_graph;
  switch (type_of_graph) {
    case 0:WriteAdjacencyMatrix(os, graph);
      break;
    case 1:WriteIncidenceMatrix(os, graph, is_directed);
      break;
    case 2:WriteAdjacencyList(os, graph);
      break;
    default:WriteListOfEdges(os, graph, is_directed);
  }
}
void WriteAdjacencyMatrix(std::ostream &os, const std::vector<std::vector<int>> &graph) {
  os << graph.size() << "\n";
  for (const auto &vertex_info : graph) {
    for (auto is_edge : vertex_info) {
      os << is_edge << " ";
    }
    os << "\n";
  }
}
void WriteIncidenceMatrix(std::ostream &os, const std::vector<std::vector<int>> &graph,
                          bool is_directed) {
  os << graph.size() << "\n";
  std::vector<std::vector<int>> transported_incidence_matrix;
  std::vector<int> next_edge;
  if (is_directed) {
    for (auto i = 0; i < graph.size(); ++i) {
      for (auto j = 0; j < graph.size(); ++j) {
        if (graph[i][j] == 1) {
          next_edge = {};
          next_edge.resize(graph.size(), 0);
          next_edge[i] = -1;
          next_edge[j] = 1;
          transported_incidence_matrix.push_back(next_edge);
        }
      }
    }
  } else {
    for (auto i = 0; i < graph.size(); ++i) {
      for (auto j = 0; j < i; ++j) {
        if (graph[i][j] == 1) {
          next_edge = {};
          next_edge.resize(graph.size(), 0);
          next_edge[i] = 1;
          next_edge[j] = 1;
          transported_incidence_matrix.push_back(next_edge);
        }
      }
    }
  }
  if (!transported_incidence_matrix.empty()) {
    for (auto i = 0; i < transported_incidence_matrix[0].size(); ++i) {
      for (auto j = 0; j < transported_incidence_matrix.size(); ++j) {
        os << transported_incidence_matrix[j][i] << " ";
      }
      os << "\n";
    }
  }
}
void WriteAdjacencyList(std::ostream &os, const std::vector<std::vector<int>> &graph) {
  os << graph.size() << "\n";
  for (const auto &vertex_info : graph) {
    for (auto i = 0; i < vertex_info.size(); ++i) {
      if (vertex_info[i] == 1) {
        os << i << " ";
      }
    }
    os << "\n";
  }
}
void WriteListOfEdges(std::ostream &os, const std::vector<std::vector<int>> &graph,
                      bool is_directed) {
  os << graph.size() << "\n";
  int number_of_edges = 0;
  for (const auto &vertex_info : graph) {
    for (auto is_edge : vertex_info) {
      number_of_edges += is_edge;
    }
  }
  if (is_directed) {
    os << number_of_edges << "\n";
  } else {
    os << number_of_edges / 2 << "\n";
  }
  if (is_directed) {
    for (auto i = 0; i < graph.size(); ++i) {
      for (auto j = 0; j < graph.size(); ++j) {
        if (graph[i][j] == 1) {
          os << i << " " << j << "\n";
        }
      }
    }
  } else {
    for (auto i = 0; i < graph.size(); ++i) {
      for (auto j = 0; j < i; ++j) {
        if (graph[i][j] == 1) {
          os << i << " " << j << "\n";
        }
      }
    }
  }
}