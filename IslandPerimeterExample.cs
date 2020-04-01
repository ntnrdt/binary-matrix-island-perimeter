using System;

namespace island_perimeter
{
    public static class IslandPerimeterExample
    {
        public static void Run()
        {
            var case1 = new int[][]{
                new []{1, 0, 1, 1, 1},
                new []{1, 0, 1, 1, 1},
                new []{0, 1, 0, 1, 1}};

            var perimeter = GetPerimeter(case1);

            Console.WriteLine($"The perimeter is: {perimeter}");
        }

        /// <summary>
        /// It will traverse for each row traversing all columns and sum the perimeters.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int GetPerimeter(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0) return 0;

            int perimeter = 0;

            // for each row
            for (var i = 0; i < grid.Length; i ++)
            {
                // for each column
                for (var j = 0; j < grid[i].Length; j++)
                {
                    // item is land 
                    if (grid[i][j] == 1)
                    {
                        // starts assuming that the perimeter has no shared border, this makes the subtraction easy
                        perimeter += 4;

                        // if not first row and previous row at the current column has land, remove 2 (they share a border)
                        if (i> 0 && grid[i -1][j]==1)
                            perimeter -= 2;

                        // if not first column and previous column has land, remove 2 (they share a border)
                        if (j > 0 && grid[i][j-1] == 1)
                            perimeter -= 2;
                    }
                }
            }

            return perimeter;
        }
    }

}