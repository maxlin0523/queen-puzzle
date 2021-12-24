using System;
using System.Collections.Generic;
using System.Text;

namespace QueensPuzzle
{
    public class Queen
    {
        /// <summary>
        /// 棋盤邊界
        /// </summary>
        private readonly int _size;

        /// <summary>
        /// 用於儲存合法情況
        /// </summary>
        private List<List<string>> _validMap;

        public Queen(int size)
        {
            _size = size;
            _validMap = new List<List<string>>();
        }

        /// <summary>
        /// 尋找合法皇后
        /// </summary>
        public string Search()
        {
            // 初始化地圖
            var map = InitMap();

            var beginIndex = 0;

            SearchQueenValidation(map, beginIndex);

            var answer = PrintMap(_validMap);

            return answer;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private string[,] InitMap()
        {
            var map = new string[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    map[i, j] = ".";
                }
            }

            return map;
        }

        /// <summary>
        /// 遞迴。將各種情況跑一遍
        /// </summary>
        /// <param name="column">目前列數</param>
        private void SearchQueenValidation(string[,] map, int column)
        {
            // 合法
            if (column == _size)
            {
                var format = FormatValidMap(map);
                _validMap.Add(format);
                return;
            }

            for (int row = 0; row < _size; row++)
            {
                // 合法則繼續搜尋
                if (IsValid(map, row, column))
                {
                    map[column, row] = "Q";
                    SearchQueenValidation(map, column + 1);
                    map[column, row] = ".";
                }
            }
        }

        /// <summary>
        /// 判斷合法情況，不合法就 return 掉
        /// </summary>
        private bool IsValid(string[,] temp, int row, int column)
        {
            // 判斷縱向是否出現皇后
            for (int y = 0; y < column; y++)
            {
                if (temp[y, row] == "Q") return false;
            }

            // 判斷斜後是否出現皇后
            for (int x = row - 1, y = column - 1; x >= 0 && y >= 0; x--, y--)
            {
                if (temp[y, x] == "Q") return false;
            }

            // 判斷斜前是否出現皇后
            for (int x = row + 1, y = column - 1; x < _size && y >= 0; x++, y--)
            {
                if (temp[y, x] == "Q") return false;
            }

            return true;
        }

        /// <summary>
        /// 轉換合法情況(二維轉一維陣列)，目的是方便儲存
        /// </summary>
        private List<string> FormatValidMap(string[,] map)
        {
            var result = new List<string>();

            foreach (var i in map)
            {
                var row = string.Empty;
                foreach (var j in i)
                {
                    row += j;
                }
                result.Add(row);
            }
            return result;
        }

        /// <summary>
        /// 印出所有合法情況
        /// </summary>
        /// <param name="map"></param>
        private string PrintMap(List<List<string>> map)
        {
            var result = new StringBuilder();

            foreach (var i in map)
            {
                var count = 1;
                foreach (var j in i)
                {
                    result.Append(j);

                    if (count % _size == 0)
                    {
                        result.AppendLine();
                    }
                    count++;
                }
                result.AppendLine();
            }

            return result.ToString();
        }

    }
}
