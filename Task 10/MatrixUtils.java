package com.company.Exercise10_11_12;

import java.util.Random;

public class MatrixUtils {
    private static final int MAX_EDGE_LENGTH = 9;

    public static int[][] generateRandomMatrix(int vertices) {
        Random random = new Random();
        int[][] matrix = new int[vertices][vertices];
        for (int row = 0; row < vertices; row++) {
            for (int column = 0; column < vertices; column++) {
                int distance = row == column ? 0 : random.nextInt(MAX_EDGE_LENGTH);
                matrix[row][column] = distance;
                matrix[column][row] = distance;
            }
        }
        return matrix;
    }

    public static String matrixAsString(int[][] matrix, int[] colors) {
        String result = "";
        int vertices = matrix[0].length;
        for (int row = 0; row < vertices; row++) {
            result += "\n";
            for (int column = 0; column < vertices; column++) {
//                result += (char) 27 + "[" + colors[row] + "m" + matrix[row][column];
                result += matrix[row][column] + " ";
            }
        }
        return result;
    }

}
