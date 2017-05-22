package com.company.Exercise10_11_12;

public class Main {

    public static void main(String[] args) {
        GraphUtils graphUtils = new GraphUtils(false);
        graphUtils.createGraph(8);
        System.out.println(graphUtils.graphAsString());
        divide();
//        graphUtils.printVisitDepthFirst(GraphUtils.START_VERTICE_RANDOM);
//        divide();
//        graphUtils.printVisitDepthFirst(GraphUtils.START_VERTICE_RANDOM);
//        divide();
//        graphUtils.printVisitDepthFirst(GraphUtils.START_VERTICE_RANDOM);
//        System.out.println();
        graphUtils.printVisitBreadthFirst(0);
        divide();
        graphUtils.printVisitBreadthFirst(2);
        divide();
        graphUtils.printVisitBreadthFirst(3);
        divide();
        graphUtils.printVisitBreadthFirst(4);
    }

    private static void divide(){
        System.out.println((char) 27 + "[0m\n");
    }
}
