using StudentsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentsApp.Requests
{
    public class GetStudentsRequest
    {
        private static readonly int LimitMin = 1;
        private static readonly int LimitMax = int.MaxValue;
        private static readonly int IdMin = 1;
        private static readonly int IdMax = int.MaxValue;

        private int _limit = LimitMax;
        private int _offset = 0;
        private string _sort = "ID";
        private int _minId = IdMin;
        private int _maxId = IdMax;
        private string _columns = "ID,NAME,PHONE";
        private string _like = "";
        private string _globalLike = "";

        public int Limit
        {
            get => _limit;
            set
            {
                if (value < LimitMin) 
                    _limit = LimitMin;
                else if (value > LimitMax) 
                    _limit = LimitMax;
                else
                    _limit = value;
            } 
        }
        public int Offset
        {
            get => _offset;
            set
            {
                if (value > 0)
                    _offset = value;
            }
        }
        public string Sort
        {
            get => _sort;
            set
            {
                if (Student.Columns.Contains(value.ToUpper()))
                    _sort = value.ToUpper();
            }
        }
        public int MinId
        {
            get => _minId;
            set
            {
                if (value < IdMin)
                    _minId = IdMin;
                else if (value > IdMax)
                    _minId = IdMax;
                else
                    _minId = value;
            }
        }
        public int MaxId 
        {
            get => _maxId;
            set
            {
                if (value < IdMin)
                    _maxId = IdMin;
                else if (value > IdMax)
                    _maxId = IdMax;
                else
                    _maxId = value;
            }
        }
        public string Columns
        {
            get => _columns;
            set
            {
                var columns = new List<string>(3);
                var queryColumns = value.Split(',').ToArray();

                if (queryColumns.Count() == 0)
                    return;

                foreach (var c in queryColumns)
                {
                    if (Student.Columns.Contains(c.ToUpper()))
                        columns.Add(c.ToUpper());
                }

                if (columns.Count() != 0)
                    _columns = string.Join(",", columns).Replace(" ", string.Empty).TrimEnd(',');
            }
        }
        public string Like { get => _like.Replace(" ", string.Empty); set => _like = string.IsNullOrWhiteSpace(value) ? "" : value; }
        public string GlobalLike { get => _globalLike.Replace(" ", string.Empty); set => _globalLike = string.IsNullOrWhiteSpace(value) ? "" : value; }
    }
}