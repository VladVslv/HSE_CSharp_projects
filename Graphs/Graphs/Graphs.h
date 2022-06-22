#include <iostream>
#include <vector>
#include <sstream>
#include <fstream>
#ifndef GRAPHS__GRAPHS_H_
#define GRAPHS__GRAPHS_H_

/// Метод для выполнения действий с графом и их повторения.
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
/// Граф, с которым выполняются действия. \param graph
void MakeActionsWithGraph(bool is_directed, const std::vector<std::vector<int>> &graph);

/// Чтение графа, сохраненного в указанном виде, и возвращение графа в виде матрицы смежности.
/// Поток для чтения графа. \param is
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
/// Переменная указывающая на то, читаем ли мы с консоли. \param is_from_console
/// Граф в виде матрицы смежности. \return
std::vector<std::vector<int>> ReadGraph(std::istream &is, bool is_directed, bool is_from_console);

/// Чтение графа в виде матрицы смежности.
/// Поток для чтения графа. \param is
/// Граф в виде матрицы смежности. \return
std::vector<std::vector<int>> ReadAdjacencyMatrix(std::istream &is);

/// Чтение графа в виде матрицы инцидентности и возвращение графа в виде матрицы смежности.
/// Поток для чтения графа. \param is
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
/// Граф в виде матрицы смежности. \return
std::vector<std::vector<int>> ReadIncidenceMatrix(std::istream &is, bool is_directed);

/// Чтение графа, записанного в виде списка смежности, и возвращение в виде матрицы смежности.
/// Поток для чтения графа. \param is
/// Граф в виде матрицы смежности. \return
std::vector<std::vector<int>> ReadAdjacencyList(std::istream &is);

/// Чтение графа, записанного в виде списка рёбер, и возвращение в виде матрицы смежности.
/// Поток для чтения графа. \param is
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
/// Граф в виде матрицы смежности. \return
std::vector<std::vector<int>> ReadListOfEdges(std::istream &is, bool is_directed);

/// Подсчет степеней вершин для неориентированного графа и
/// полустепеней вершин для ориентированного графа и вывод данных в консоль.
/// Граф в виде матрицы смежности. \param graph
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
void CountDegrees(const std::vector<std::vector<int>> &graph, bool is_directed);

/// Подсчет количества ребер (для неориентированного)/дуг (для ориентированного)
/// графа и вывод данных в консоль.
/// Граф в виде матрицы смежности. \param graph
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
void CountEdges(const std::vector<std::vector<int>> &graph, bool is_directed);

/// Запись графа в указанном виде.
/// Поток для записи графа. \param os
/// Граф в виде матрицы смежности. \param graph
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
void WriteGraph(std::ostream &os, const std::vector<std::vector<int>> &graph, bool is_directed);

/// Запись графа в виде матрицы смежности.
/// Поток для записи графа. \param os
/// Граф в виде матрицы смежности. \param graph
void WriteAdjacencyMatrix(std::ostream &os, const std::vector<std::vector<int>> &graph);

/// Запись графа в виде матрицы инцидентности.
/// Поток для записи графа. \param os
/// Граф в виде матрицы смежности. \param graph
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
void WriteIncidenceMatrix(std::ostream &os, const std::vector<std::vector<int>> &graph,
                          bool is_directed);

/// Запись графа в виде списка смежности.
/// Поток для записи графа. \param os
/// Граф в виде матрицы смежности. \param graph
void WriteAdjacencyList(std::ostream &os, const std::vector<std::vector<int>> &graph);

/// Запись графа в виде списка рёбер.
/// Поток для записи графа. \param os
/// Граф в виде матрицы смежности. \param graph
/// Переменная указывающая на то, является ли граф ориентированным. \param is_directed
void WriteListOfEdges(std::ostream &os, const std::vector<std::vector<int>> &graph,
                      bool is_directed);
#endif //GRAPHS__GRAPHS_H_
