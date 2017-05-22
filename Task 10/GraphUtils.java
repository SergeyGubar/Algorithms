package com.company.Exercise10_11_12;

import java.util.AbstractQueue;
import java.util.ArrayDeque;
import java.util.Queue;
import java.util.Random;

public class GraphUtils {
    public static final int START_VERTICE_RANDOM = -123;
    private int numberOfVertices;
    private int[][] matrix;
    private int[] colors;
    private boolean isAssignColors;
    private Random random;

    public GraphUtils(boolean isAssignColors) {
        this.isAssignColors = isAssignColors;
        random = new Random();
        /**
         * Just to prevent crashes if matrix is not set.
         */
        matrix = new int[0][0];
    }

    public String graphAsString() {
        return MatrixUtils.matrixAsString(matrix, colors);
    }

    public void createGraph(int numberOfVertices) {
        if (numberOfVertices > 8 && isAssignColors) {
            try {
                throw new TooManyNodesException("Max number of nodes is 8, because there are only 8 different colors available");
            } catch (TooManyNodesException e) {
                e.printStackTrace();
            }
        } else {
            this.numberOfVertices = numberOfVertices;
            initMatrix();
            if (isAssignColors) {
                assignColors();
            }
        }
    }

    public void printVisitDepthFirst(int startVertice) {
        boolean[] visited = new boolean[numberOfVertices];
        if (startVertice == START_VERTICE_RANDOM) {
            startVertice = random.nextInt(numberOfVertices);
        }
        DFS(visited, startVertice);
    }

    private void DFS(boolean[] visited, int current) {
        String vertice = getVerticeAsString(current);
        String arrowInColor = (char) 27 + "[30m -> ";
        System.out.print(arrowInColor + vertice);
        visited[current] = true;
        for (int j = 0; j < numberOfVertices; j++) {
            if (!(visited[j]) && matrix[current][j] > 0) {
                DFS(visited, j);
            }
        }
    }

    private String getVerticeAsString(int current) {
        return isAssignColors ?
                (char) 27 + "[" + colors[current] + "m" + current :
                Integer.toString(current);
    }

    public void printVisitBreadthFirst(int startVertice) {
        Queue<Integer> queue = new ArrayDeque<Integer>();
        boolean[] visited = new boolean[numberOfVertices];
        System.out.print(startVertice);
        visited[startVertice] = true;
        queue.add(startVertice);
        while (!queue.isEmpty()) {
            int current = queue.remove();
            printAdjacentAndEnque(current, queue, visited);
        }
    }

//    private String queToString(Queue<Integer> queueToReturnInString) {
//        Queue<Integer> queue = new ArrayDeque<Integer>(queueToReturnInString);
//        String result = "";
//        while (!queue.isEmpty()) {
//            result += queue.poll();
//        }
//        return result;
//    }

    private void printAdjacentAndEnque(int vertice, Queue<Integer> queue, boolean[] visited) {
        for (int i = 0; i < numberOfVertices; i++) {
            if (matrix[vertice][i] > 0 && !visited[i]) {
                System.out.print(" -> " + i);
                queue.add(i);
                visited[i] = true;
            }
        }
    }

    private void initMatrix() {
        matrix = MatrixUtils.generateRandomMatrix(numberOfVertices);
//        matrix = new int[][]{
//                {0, 1, 0, 1, 0, 0, 1, 0},
//                {1, 0, 0, 0, 1, 1, 0, 0},
//                {0, 0, 0, 0, 0, 1, 0, 1},
//                {1, 0, 0, 0, 0, 1, 0, 0},
//                {0, 1, 0, 0, 0, 0, 1, 0},
//                {0, 1, 1, 1, 0, 0, 0, 0},
//                {1, 0, 0, 0, 1, 0, 0, 0},
//                {0, 0, 1, 0, 0, 0, 0, 0}
//        };
//        BFS output from 0 node shoukd be 0 -> 1 -> 3 -> 6 -> 4 -> 5 -> 2 -> 7
    }

    private void assignColors() {

        colors = new int[numberOfVertices];
        for (int i = 0; i < numberOfVertices; i++) {
            int randomColor = 30 + random.nextInt(8);
            while (isInColors(randomColor)) {
                randomColor = 30 + random.nextInt(8);
            }
            colors[i] = randomColor;
        }
    }

    private boolean isInColors(int colorToCheck) {
        boolean isContains = false;
        for (int color : colors) {
            if (color == colorToCheck) {
                isContains = true;
                break;
            }
        }
        return isContains;
    }
}
